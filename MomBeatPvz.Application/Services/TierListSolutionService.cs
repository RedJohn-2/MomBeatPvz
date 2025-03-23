using Microsoft.Extensions.Caching.Distributed;
using MomBeatPvz.Application.Operations.UnitOfWork;
using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Application.Services.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services
{
    public class TierListSolutionService : 
        BaseService<TierListSolution, TierListSolutionCreateModel, TierListSolutionUpdateModel, long, ITierListSolutionStore>,
        ITierListSolutionService
    {
        private readonly IHeroService _heroService;

        public TierListSolutionService(
            ITierListSolutionStore tierListSolutionStore,
            IHeroService heroService,
            IDistributedCache distributedCache)
            : base(tierListSolutionStore, distributedCache)
        {
            _heroService = heroService;
        }

        public async override Task CreateAsync(TierListSolutionCreateModel model)
        {
            _heroService.CheckDuplicates(model.HeroPrices.Select(x => x.Hero).ToList());

            await base.CreateAsync(model);
        }


        public async Task<IReadOnlyList<TierListSolution>> GetAllAsync()
        {
            return await _store.GetAll();
        }

        public async Task<IReadOnlyList<TierListSolution>> GetByTierListIdAsync(long id)
        {
            return await _store.GetByTierListId(id);
        }

        public async override Task UpdateAsync(TierListSolutionUpdateModel model)
        {
            if (model.HeroPrices is not null)
            {
                _heroService.CheckDuplicates(model.HeroPrices.Select(x => x.Hero).ToList());
            }

            await _store.Update(model);
        }
    }
}
