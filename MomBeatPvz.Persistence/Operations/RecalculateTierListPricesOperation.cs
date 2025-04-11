using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Application.Operations;
using MomBeatPvz.Application.Operations.UnitOfWork;
using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Operations
{
    public class RecalculateTierListPricesOperation : IRecalculateTierListPricesOperation
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RecalculateTierListPricesOperation(
            ApplicationContext db, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _db = db;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Operate(CancellationToken cancellationToken)
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var tierLists = await _db.TierLists
                    .Where(x => x.Championship.Stage == ChampionshipStage.TierListVouting)
                    .Include(t => t.Result)
                    .Include(t => t.Solutions)
                    .ThenInclude(s => s.HeroPrices)
                    .ToListAsync(cancellationToken);

                if (tierLists.Count == 0)
                {
                    return;
                }

                var heroMap = await _db.Heroes.ToDictionaryAsync(h => h.Id, h => h, cancellationToken);

                foreach (var tierList in tierLists)
                {
                    await RecalculateTierList(tierList, heroMap, cancellationToken);
                }
            }, cancellationToken);
        }

        public async Task RecalculateTierList(
            TierListEntity tierList, 
            Dictionary<int, HeroEntity> heroMap, 
            CancellationToken cancellationToken)
        {
            var pricesMap = tierList.Solutions
                .Where(s => s.OwnerId is not null)
                .SelectMany(s => s.HeroPrices)
                .GroupBy(p => p.Hero.Id)               
                .ToDictionary(g => g.Key, g => g.Select(g => g.Value));

            if (pricesMap.Count != 0)
            {
                var resultPrices = new List<HeroPriceEntity>();

                foreach (var item in pricesMap)
                {
                    var frequencyPrices = item.Value
                        .GroupBy(v => v)
                        .Select(g => new
                        {
                            Value = g.Key,
                            Count = g.Count()
                        });

                    var mostFrequency = frequencyPrices.Max(f => f.Count);

                    var mostFrequentValues = frequencyPrices
                        .Where(f => f.Count == mostFrequency)
                        .Select(f => f.Value);

                    resultPrices.Add(new HeroPriceEntity
                    {
                        Hero = heroMap[item.Key],
                        Value = (int)Math.Ceiling(mostFrequentValues.Average())
                    });
                }

                if (tierList.Result is null)
                {
                    tierList.Result = new TierListSolutionEntity { TierList = tierList };
                }

                tierList.Result.HeroPrices = resultPrices;

                _db.TierListSolutions.Attach(tierList.Result);

                var entries = _db.ChangeTracker.Entries();

                await _db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
