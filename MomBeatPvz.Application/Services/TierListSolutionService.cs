using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Operations.UnitOfWork;
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
    public class TierListSolutionService : ITierListSolutionService
    {
        private readonly ITierListSolutionStore _tierListSolutionStore;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHeroService _heroService;

        public TierListSolutionService(
            ITierListSolutionStore tierListSolutionStore,
            IUnitOfWork unitOfWork,
            IHeroService heroService)
        {
            _tierListSolutionStore = tierListSolutionStore;
            _unitOfWork = unitOfWork;
            _heroService = heroService;
        }

        public async Task CreateAsync(TierListSolutionCreateModel model)
        {
            _heroService.CheckDuplicates(model.HeroPrices.Select(x => x.Hero).ToList());

            await _tierListSolutionStore.Create(model);
        }

        public async Task DeleteAsync(long id)
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var solutionExist = await _tierListSolutionStore.Exist(id);

                if (solutionExist)
                {
                    await _tierListSolutionStore.Delete(id);
                }
            });
            
        }

        public async Task<IReadOnlyList<TierListSolution>> GetAllAsync()
        {
            return await _tierListSolutionStore.GetAll();
        }

        public async Task<TierListSolution> GetByIdAsync(long id)
        {
            return await _tierListSolutionStore.GetById(id);
        }

        public async Task<IReadOnlyList<TierListSolution>> GetByTierListIdAsync(long id)
        {
            return await _tierListSolutionStore.GetByTierListId(id);
        }

        public async Task UpdateAsync(TierListSolutionUpdateModel model)
        {
            if (model.HeroPrices is not null)
            {
                _heroService.CheckDuplicates(model.HeroPrices.Select(x => x.Hero).ToList());
            }

            await _tierListSolutionStore.Update(model);
        }
    }
}
