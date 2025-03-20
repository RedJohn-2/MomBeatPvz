using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Core.Exceptions;
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
        private readonly ITeamService _teamService;

        public MatchService(IMatchStore matchStore, ITeamService teamService)
        {
            _matchStore = matchStore;
            _teamService = teamService;
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
            if (model.Results is not null)
            {
                _teamService.CheckDuplicates(model.Results.Select(x => x.Team).ToList());
            }

            await _matchStore.Update(model);
        }

        public void CheckDuplicates(List<Match> matches)
        {
            var uniqueMatches = matches.Select(x => x.Id).Distinct().Count();

            if (matches.Count != uniqueMatches)
            {
                throw new DuplicateException("Дубликаты матчей!");
            }
        }
    }
}
