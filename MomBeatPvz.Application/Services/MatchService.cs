using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchStore _matchStore;

        public MatchService(IMatchStore matchStore)
        {
            _matchStore = matchStore;
        }

        public async Task CreateAsync(MatchCreateModel model)
        {
            await _matchStore.Create(model);
        }

        public async Task<Match> GetByIdAsync(long id)
        {
            return await _matchStore.GetById(id);
        }

        public async Task UpdateAsync(MatchUpdateModel model)
        {
            await _matchStore.Update(model);
        }
    }
}
