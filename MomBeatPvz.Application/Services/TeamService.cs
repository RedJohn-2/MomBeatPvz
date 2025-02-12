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
    public class TeamService : ITeamService
    {
        private readonly ITeamStore _teamStore;

        public TeamService(ITeamStore teamStore)
        {
            _teamStore = teamStore;
        }

        public async Task CreateAsync(TeamCreateModel model)
        {          
            await _teamStore.Create(model);
        }

        public async Task<Team> GetByIdAsync(long id)
        {
            return await _teamStore.GetById(id);
        }

        public async Task UpdateAsync(TeamUpdateModel model)
        {
            await _teamStore.Update(model);
        }
    }
}
