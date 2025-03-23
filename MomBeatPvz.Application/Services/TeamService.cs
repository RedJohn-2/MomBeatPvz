using Microsoft.Extensions.Caching.Distributed;
using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Application.Services.Interfaces;
using MomBeatPvz.Core.Exceptions;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services
{
    public class TeamService : 
        BaseService<Team, TeamCreateModel, TeamUpdateModel, long, ITeamStore>,
        ITeamService
    {
        private readonly IHeroService _heroService;

        public TeamService(ITeamStore teamStore, IHeroService heroService, IDistributedCache) : base(teamStore, distributedCache)
        {
            _heroService = heroService;
        }

        public async override Task CreateAsync(TeamCreateModel model)
        {
            CheckTeamSize(model.Heroes);

            _heroService.CheckDuplicates(model.Heroes);

            await base.CreateAsync(model);
        }

        private static void CheckTeamSize(List<Hero> heroes)
        {
            if (heroes.Count != 3)
            {
                throw new BadRequestException("Недопустимое число персонажей в команде!!!");
            }
        }

        public async override Task UpdateAsync(TeamUpdateModel model)
        {
            if (model.Heroes is not null)
            {
                CheckTeamSize(model.Heroes);

                _heroService.CheckDuplicates(model.Heroes);
            }

            await base.UpdateAsync(model);
        }

        public void CheckDuplicates(List<Team> teams)
        {
            var uniqueTeams = teams.Select(x => x.Id).Distinct().Count();

            if (teams.Count != uniqueTeams)
            {
                throw new DuplicateException("Дубликаты команд!");
            }
        }
    }
}
