using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services
{
    public class TierListService : ITierListService
    {
        private readonly ITierListStore _tierListStore;

        public TierListService(ITierListStore tierListStore)
        {
            _tierListStore = tierListStore;
        }

        public async Task CreateAsync(TierListCreateModel model)
        {
            await _tierListStore.Create(model);
        }

        public async Task UpdateAsync(TierListUpdateModel model)
        {
            await _tierListStore.Update(model);
        }

        public async Task<TierList> GetByIdAsync(long id)
        {
            return await _tierListStore.GetById(id);
        }
    }
}
