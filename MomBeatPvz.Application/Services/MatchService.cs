﻿using Microsoft.Extensions.Caching.Distributed;
using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Application.Services.Interfaces;
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
    public class MatchService : 
        BaseService<Match, MatchCreateModel, MatchUpdateModel, long, IMatchStore>,
        IMatchService
    {
        private readonly ITeamService _teamService;

        public MatchService(
            IMatchStore matchStore,
            IDistributedCache distributedCache,
            ITeamService teamService) : base(matchStore, distributedCache)
        {
            _teamService = teamService;
        }

        public async override Task UpdateAsync(MatchUpdateModel model)
        {
            if (model.Results is not null)
            {
                _teamService.CheckDuplicates(model.Results.Select(x => x.Team).ToList());
            }

            await base.UpdateAsync(model);
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
