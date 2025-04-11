using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Application.Operations.UnitOfWork;
using MomBeatPvz.Core.Enums;
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
    public class TeamRepository :
        BaseRepository<Team, TeamCreateModel, TeamUpdateModel, TeamEntity, long>,
        ITeamStore
    {
        public TeamRepository(ApplicationContext db, IMapper mapper, IUnitOfWork unitOfWork) : base(db, mapper, unitOfWork)
        {
        }

        public async override Task Create(TeamCreateModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TeamEntity>(model);

            await _unitOfWork.InTransaction(async () =>
            {
                var championship = await _db.Championships
                    .FirstOrDefaultAsync(x => x.Id == entity.ChampionshipId, cancellationToken)
                    ?? throw new NotFoundException();

                if (championship.TierListId is null || championship.Stage != ChampionshipStage.CreatingTeams)
                {
                    throw new BadRequestException("Создавать команду на данный момент нельзя!");
                }

                var teamExist = await _db.Teams
                    .Where(x => x.ChampionshipId == entity.Championship.Id && x.AuthorId == entity.Author.Id)
                    .AnyAsync(cancellationToken);

                if (teamExist)
                {
                    throw new DuplicateException("Ваша команда для данного чемпионата уже существует! Измените существующую команду!");
                }

                entity.Championship = championship;

                await ValidateHeroes(entity, cancellationToken);

                _db.Attach(entity);

                var entries = _db.ChangeTracker.Entries();

                await _db.SaveChangesAsync(cancellationToken);
            }, cancellationToken);
        }

        public async override Task Update(TeamUpdateModel model, CancellationToken cancellationToken)
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var existedTeam = await _db.Teams
                   .Include(x => x.Championship)
                   .FirstOrDefaultAsync(s => s.Id == model.Id, cancellationToken)
                   ?? throw new NotFoundException();

                if (existedTeam.AuthorId != model.AuthorId)
                {
                    throw new ForbiddenException("Нельзя изменять чужую команду!");
                }

                if (existedTeam.Championship.TierListId is null 
                    || existedTeam.Championship.Stage != ChampionshipStage.CreatingTeams)
                {
                    throw new BadRequestException("Изменять команду на данный момент нельзя!");
                }

                _mapper.Map(model, existedTeam);

                var entries = _db.ChangeTracker.Entries();

                if (existedTeam.Heroes is not null)
                {
                    await ValidateHeroes(existedTeam, cancellationToken);
                }

                entries = _db.ChangeTracker.Entries();

                await _db.SaveChangesAsync(cancellationToken);
            }, cancellationToken);
        }

        private async Task ValidateHeroes(TeamEntity entity, CancellationToken cancellationToken)
        {
            var heroInTeamIds = entity.Heroes.Select(x => x.Id).ToArray();

            var heroesInChampionshipIds = await _db.Championships
                .Where(x => x.Id == entity.Championship.Id)
                .SelectMany(x => x.Heroes)
                .Select(x => x.Id)
                .ToArrayAsync(cancellationToken);

            if (!heroInTeamIds.All(x => heroesInChampionshipIds.Contains(x)))
            {
                throw new BadRequestException("Недопустимые персонажи в команде!");
            }

            var tierListQuery = _db.TierLists
                .Where(x => x.Id == entity.Championship.TierListId);

            var teamPrice = await tierListQuery
                .SelectMany(x => x.Result!.HeroPrices)
                .Select(x => new
                {
                    HeroId = x.Hero.Id,
                    Price = x.Value
                })
                .Where(x => heroInTeamIds.Contains(x.HeroId))
                .SumAsync(x => x.Price, cancellationToken);

            if (teamPrice > entity.Championship.TeamPrice)
            {
                throw new BadRequestException("Команда слишком дорогая!!!");
            }
        }

        public async override Task<Team> GetById(long id, CancellationToken cancellationToken)
        {
            var existed = await _db.Teams
                .Include(t => t.Author)
                .Include(t => t.Heroes)
                .Include(t => t.Championship)
                .FirstOrDefaultAsync(x => x.Id!.Equals(id), cancellationToken);

            return _mapper.Map<Team>(existed);
        }

        public async override Task<IReadOnlyCollection<Team>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _db.Teams
                .Include(x => x.Author)
                .Include(x => x.Heroes)
                .Include(t => t.Championship)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IReadOnlyCollection<Team>>(entities);
        }
    }
}
