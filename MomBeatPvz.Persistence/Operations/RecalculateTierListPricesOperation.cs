using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Application.Operations;
using MomBeatPvz.Application.Operations.UnitOfWork;
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

        public async Task Operate()
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var tierLists = await _db.TierLists
                .Include(t => t.Result)
                .Include(t => t.Solutions)
                .ThenInclude(s => s.HeroPrices)
                .ToListAsync();

                var heroMap = await _db.Heroes.ToDictionaryAsync(h => h.Id, h => h);

                foreach (var tierList in tierLists)
                {
                    await RecalculateTierList(tierList, heroMap);
                }
            });
        }

        public async Task RecalculateTierList(TierListEntity tierList, Dictionary<int, HeroEntity> heroMap)
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

                var result = new TierListSolutionEntity();

                if (tierList.Result is not null)
                {
                    await _db.HeroPrices
                    .Where(p => p.Solution == tierList.Result)
                    .ExecuteDeleteAsync();
                }
                else
                {
                    result.TierList = tierList;
                }

                result.HeroPrices = resultPrices;

                _db.TierListSolutions.Attach(result);

                var entries = _db.ChangeTracker.Entries();

                await _db.SaveChangesAsync();
            }
        }
    }
}
