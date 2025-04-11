using Microsoft.Extensions.Caching.Distributed;
using MomBeatPvz.Application.Interfaces;
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
            ICacheProvider cache,
            IHeroService heroService, 
            ITeamService teamService, 
            IMatchService matchService) : base(championshipStore, cache)
        {
            _heroService = heroService;
            _teamService = teamService;
            _matchService = matchService;
        }

        protected override string ModelName => nameof(Championship);

        public async override Task CreateAsync(ChampionshipCreateModel model, CancellationToken cancellationToken)
        {
            _heroService.CheckDuplicates(model.Heroes);

            await base.CreateAsync(model, cancellationToken);
        }

        public async override Task UpdateAsync(ChampionshipUpdateModel model, CancellationToken cancellationToken)
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

            await base.UpdateAsync(model, cancellationToken);
        }
    }
}
