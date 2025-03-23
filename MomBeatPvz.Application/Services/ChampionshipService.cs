using Microsoft.Extensions.Caching.Distributed;
using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Application.Services.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services
{
    public class ChampionshipService : 
        BaseService<Championship, ChampionshipCreateModel, ChampionshipUpdateModel, long, IChampionshipStore>,
        IChampionshipService
    {
        private readonly IHeroService _heroService;
        private readonly ITeamService _teamService;
        private readonly IMatchService _matchService;

        public ChampionshipService(
            IChampionshipStore championshipStore, 
            IDistributedCache distributedCache,
            IHeroService heroService, 
            ITeamService teamService, 
            IMatchService matchService) : base(championshipStore, distributedCache)
        {
            _heroService = heroService;
            _teamService = teamService;
            _matchService = matchService;
        }

        public async override Task CreateAsync(ChampionshipCreateModel model)
        {
            _heroService.CheckDuplicates(model.Heroes);

            await base.CreateAsync(model);
        }

        public async override Task UpdateAsync(ChampionshipUpdateModel model)
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

            await base.UpdateAsync(model);
        }
    }
}
