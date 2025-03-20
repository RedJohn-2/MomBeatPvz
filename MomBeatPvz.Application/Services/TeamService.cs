using MomBeatPvz.Application.Interfaces;
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
    public class TeamService : ITeamService
    {
        private readonly ITeamStore _teamStore;
        private readonly IHeroService _heroService;

        public TeamService(ITeamStore teamStore, IHeroService heroService)
        {
            _teamStore = teamStore;
            _heroService = heroService;
        }

        public async Task CreateAsync(TeamCreateModel model)
        {
            CheckTeamSize(model.Heroes);

            _heroService.CheckDuplicates(model.Heroes);

            await _teamStore.Create(model);
        }

        private static void CheckTeamSize(List<Hero> heroes)
        {
            if (heroes.Count != 3)
            {
                throw new BadRequestException("Недопустимое число персонажей в команде!!!");
            }
        }

        public async Task<Team> GetByIdAsync(long id)
        {
            return await _teamStore.GetById(id);
        }

        public async Task UpdateAsync(TeamUpdateModel model)
        {
            if (model.Heroes is not null)
            {
                CheckTeamSize(model.Heroes);

                _heroService.CheckDuplicates(model.Heroes);
            }

            await _teamStore.Update(model);
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
