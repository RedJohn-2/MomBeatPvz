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

        public TierListSolutionService(
            ITierListSolutionStore tierListSolutionStore,
            IUnitOfWork unitOfWork)
        {
            _tierListSolutionStore = tierListSolutionStore;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(TierListSolutionCreateModel model)
        {
            await _tierListSolutionStore.Create(model);
        }

        public async Task DeleteAsync(long id)
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var solution = await _tierListSolutionStore.GetById(id);

                if (solution != null)
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
            await _tierListSolutionStore.Update(model);
        }
    }
}
