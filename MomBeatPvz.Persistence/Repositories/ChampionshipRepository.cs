using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Application.Operations.UnitOfWork;
using MomBeatPvz.Core.Exceptions;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Persistence.Entities;
using MomBeatPvz.Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Repositories
{
    public class ChampionshipRepository :
        BaseRepository<Championship, ChampionshipCreateModel, ChampionshipUpdateModel, ChampionshipEntity, long>,
        IChampionshipStore
    {
        public ChampionshipRepository(ApplicationContext db, IMapper mapper, IUnitOfWork unitOfWork) : base(db, mapper, unitOfWork)
        {
        }

        public async override Task Update(ChampionshipUpdateModel model, CancellationToken cancellationToken)
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var existed = await _db.Championships
                .Include(x => x.Heroes)
                .Include(x => x.Creator)
                .FirstOrDefaultAsync(x => x.Id!.Equals(model.Id), cancellationToken)
                ?? throw new NotFoundException();

                if (existed.Creator.Id != model.AuthorId)
                {
                    throw new ForbiddenException("Нельзя редактировать чужой тирлист!");
                }

                _mapper.Map(model, existed);

                if (model.Heroes is not null)
                {
                    var existedHeroIds = existed.Heroes.Select(x => x.Id).ToArray();

                    var newHeroIds = model.Heroes.Select(x => x.Id).ToArray();

                    existed.Heroes.RemoveAll(x => !newHeroIds.Contains(x.Id));

                    if (!newHeroIds.All(x => existedHeroIds.Contains(x)))
                    {
                        var newHeroes = newHeroIds
                        .Where(x => !existedHeroIds.Contains(x))
                        .Select(x => new HeroEntity { Id = x })
                        .ToList();

                        _db.AttachRange(newHeroes);

                        existed.Heroes.AddRange(newHeroes);
                    }
                }

                if (model.Matches is not null)
                {
                    var existedMatchIds = existed.Matches.Select(x => x.Id).ToArray();

                    var newMatchIds = model.Matches.Select(x => x.Id).ToArray();

                    existed.Matches.RemoveAll(x => !newMatchIds.Contains(x.Id));

                    existed.Matches.AddRange(newMatchIds
                        .Where(x => !existedMatchIds.Contains(x))
                        .Select(x => new MatchEntity { Id = x })
                        .ToList());
                }

                if (model.Teams is not null)
                {
                    var existedTeamIds = existed.Teams.Select(x => x.Id).ToArray();

                    var newTeamIds = model.Teams.Select(x => x.Id).ToArray();

                    existed.Teams.RemoveAll(x => !newTeamIds.Contains(x.Id));

                    existed.Teams.AddRange(newTeamIds
                        .Where(x => !existedTeamIds.Contains(x))
                        .Select(x => new TeamEntity { Id = x })
                        .ToList());
                }

                var entries = _db.ChangeTracker.Entries();

                await _db.SaveChangesAsync(cancellationToken);
            }, cancellationToken);
        }

        public async override Task<Championship> GetById(long id, CancellationToken cancellationToken)
        {
            var existed = await _db.Championships
                .Include(c => c.TierList)
                .Include(c => c.Creator)
                .Include(c => c.Heroes)
                .Include(c => c.Matches)
                .Include(c => c.Teams)
                .FirstOrDefaultAsync(x => x.Id!.Equals(id), cancellationToken);

            return _mapper.Map<Championship>(existed);
        }

        public async override Task<IReadOnlyCollection<Championship>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _db.Championships
                .Include(x => x.Creator)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IReadOnlyCollection<Championship>>(entities);
        }
    }
}
