using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Application.Operations;
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

        public RecalculateTierListPricesOperation(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Operate()
        {
            var tierLists = await _db.TierLists
                .Include(t => t.Result)
                .Include(t => t.Solutions)
                .ThenInclude(s => s.HeroPrices)
                .ToListAsync();

            var heroMap = await _db.Heroes.ToDictionaryAsync(h => h.Id, h => h);

            tierLists.ForEach(async x => await RecalculateTierList(x, heroMap));
        }

        public async Task RecalculateTierList(TierListEntity tierList, Dictionary<int, HeroEntity> heroMap)
        {
            var pricesMap = tierList.Solutions
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

                tierList.Result.HeroPrices = resultPrices;              
            }

            await _db.SaveChangesAsync();
        }
    }
}
