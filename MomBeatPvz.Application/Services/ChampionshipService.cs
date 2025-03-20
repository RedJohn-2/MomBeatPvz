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
        private readonly IHeroService _heroService;
        private readonly ITeamService _teamService;
        private readonly IMatchService _matchService;

        public ChampionshipService(
            IChampionshipStore championshipStore, 
            IHeroService heroService, 
            ITeamService teamService, 
            IMatchService matchService)
        {
            _championshipStore = championshipStore;
            _heroService = heroService;
            _teamService = teamService;
            _matchService = matchService;
        }

        public async Task CreateAsync(ChampionshipCreateModel model)
        {
            _heroService.CheckDuplicates(model.Heroes);

            await _championshipStore.Create(model);
        }

        public async Task<Championship> GetByIdAsync(long id)
        {
            return await _championshipStore.GetById(id);
        }

        public async Task UpdateAsync(ChampionshipUpdateModel model)
        {
            if (model.Heroes is not null)
            {
                _heroService.CheckDuplicates(model.Heroes);
            }

            if (model.Teams is not null)
            {
                _teamService.CheckDuplicates(model.Teams);
            }

            if (model.Matches is not null)
            {
                _matchService.CheckDuplicates(model.Matches);
            }

            await _championshipStore.Update(model);
        }
    }
}
