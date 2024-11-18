using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services
{
    public class TierListSolutionService : ITierListSolutionService
    {
        private readonly ITierListSolutionStore _tierListSolutionStore;

        public TierListSolutionService(ITierListSolutionStore tierListSolutionStore)
        {
            _tierListSolutionStore = tierListSolutionStore;
        }

        public async Task CreateAsync(TierListSolutionCreateModel model)
        {
            await _tierListSolutionStore.Create(model);
        }

        public async Task DeleteAsync(long id)
        {
            await _tierListSolutionStore.Delete(id);
        }

        public async Task<IReadOnlyList<TierListSolution>> GetAllAsync()
        {
            return await _tierListSolutionStore.GetAll();
        }

        public async Task<TierListSolution> GetByIdAsync(long id)
        {
            return await _tierListSolutionStore.GetById(id);
        }

        public async Task UpdateAsync(TierListSolutionUpdateModel model)
        {
            await _tierListSolutionStore.Update(model);
        }
    }
}
