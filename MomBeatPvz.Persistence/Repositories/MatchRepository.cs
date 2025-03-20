using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Application.Operations.UnitOfWork;
using MomBeatPvz.Core.Exceptions;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Persistence.Entities;
using MomBeatPvz.Persistence.Entities.Abstract;
using MomBeatPvz.Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Repositories
{
    public class MatchRepository :
        BaseRepository<Match, MatchCreateModel, MatchUpdateModel, MatchEntity, long>,
        IMatchStore
    {
        public MatchRepository(ApplicationContext db, IMapper mapper, IUnitOfWork unitOfWork) : base(db, mapper, unitOfWork)
        {
        }

        public async override Task Create(MatchCreateModel model)
        {
            var entity = _mapper.Map<MatchEntity>(model);

            _db.Entry(entity.Championship).State = EntityState.Unchanged;

            var entries = _db.ChangeTracker.Entries();

            _db.Matches.Attach(entity);            

            entries = _db.ChangeTracker.Entries();

            await _db.SaveChangesAsync();
        }

        public async override Task<Match> GetById(long id)
        {
            var existed = await _db.Matches
                .Include(m => m.Results)
                .FirstOrDefaultAsync(x => x.Id!.Equals(id));

            return _mapper.Map<Match>(existed);
        }

        public async override Task<IReadOnlyList<Match>> GetAll()
        {
            var entities = await _db.Matches.ToListAsync();

            return _mapper.Map<IReadOnlyList<Match>>(entities);
        }

        public async override Task Update(MatchUpdateModel model)
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var existedMatch = await _db.Matches
                    .Include(x => x.Championship)
                    .Include(x => x.Results)
                    .FirstOrDefaultAsync(s => s.Id == model.Id)
                    ?? throw new NotFoundException();

                _mapper.Map(model, existedMatch);

                if (model.Results is not null)
                {
                    var teamsMap = _db.Teams
                    .Where(x => existedMatch.Results
                        .Select(x => x.Team.Id)
                        .Contains(x.Id))
                    .ToDictionary(x => x.Id, x => x);

                    existedMatch.Results.ForEach(x => x.Team = teamsMap[x.Team.Id]);

                    await ValidateTeams(existedMatch);
                }                

                var entries = _db.ChangeTracker.Entries();

                await _db.SaveChangesAsync();
            });
        }

        private async Task ValidateTeams(MatchEntity entity)
        {
            var teamInMatchIds = entity.Results.Select(x => x.Team.Id).ToArray();

            var teamInChampionshipIds = await _db.Championships
                .Where(x => x.Id == entity.Championship.Id)
                .SelectMany(x => x.Teams)
                .Select(x => x.Id)
                .ToArrayAsync();

            if (!teamInMatchIds.All(x => teamInChampionshipIds.Contains(x)))
            {
                throw new NotFoundException("Недопустимые команды в матче!");
            }
        }
    }
}
