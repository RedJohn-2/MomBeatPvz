using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services
{
    public class ChampionshipService : IChampionshipService
    {
        private readonly IChampionshipStore _championshipStore;

        public ChampionshipService(IChampionshipStore championshipStore)
        {
            _championshipStore = championshipStore;
        }

        public async Task CreateAsync(ChampionshipCreateModel model)
        {
            await _championshipStore.Create(model);
        }

        public async Task<Championship> GetByIdAsync(long id)
        {
            return await _championshipStore.GetById(id);
        }

        public async Task UpdateAsync(ChampionshipUpdateModel model)
        {
            await _championshipStore.Update(model);
        }
    }
}
