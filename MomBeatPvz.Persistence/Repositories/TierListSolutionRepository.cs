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
using MomBeatPvz.Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Repositories
{
    public class TierListSolutionRepository :
        BaseRepository<TierListSolution, TierListSolutionCreateModel, TierListSolutionUpdateModel, TierListSolutionEntity, long>,
        ITierListSolutionStore
    {
        public TierListSolutionRepository(ApplicationContext db, IMapper mapper, IUnitOfWork unitOfWork) : base(db, mapper, unitOfWork)
        {
        }

        public override async Task Create(TierListSolutionCreateModel model)
        {
            var entity = _mapper.Map<TierListSolutionEntity>(model);

            await _unitOfWork.InTransaction(async () =>
            {
                var championship = await _db.Championships
                    .FirstOrDefaultAsync(x => x.TierListId == entity.TierList.Id)
                    ?? throw new NotFoundException();

                if (championship.Stage != ChampionshipStage.TierListVouting)
                {
                    throw new BadRequestException("Создавать решения для тирлистов на данный момент нельзя!");
                }

                var solutionExist = await _db.TierListSolutions
                    .Where(x => x.TierListId == entity.TierList.Id && x.OwnerId == entity.Owner!.Id)
                    .AnyAsync();

                if (solutionExist)
                {
                    throw new DuplicateException("Ваше решение для данного тирлиста уже существует! Измените существующее решение!");
                }
               
                await ValidateHeroes(entity);

                _db.Entry(entity.TierList).State = EntityState.Unchanged;

                _db.TierListSolutions.Attach(entity);

                var entries = _db.ChangeTracker.Entries();

                await _db.SaveChangesAsync();
            });
        }

        private async Task ValidateHeroes(TierListSolutionEntity entity)
        {
            var heroInSolutionIds = entity.HeroPrices.Select(x => x.Hero.Id).ToArray();

            var heroesInTierListIds = await _db.TierLists
                .Where(x => x.Id == entity.TierListId)
                .SelectMany(x => x.Championship.Heroes)
                .Select(x => x.Id)
                .ToArrayAsync();

            if (!heroInSolutionIds.All(x => heroesInTierListIds.Contains(x)))
            {
                throw new NotFoundException("Недопустимые персонажи в тирлисте!");
            }
        }

        public override async Task<IReadOnlyList<TierListSolution>> GetAll()
        {
            var solutionEntities = await _db.TierListSolutions
                .Include(s => s.Owner)
                .Include(s => s.HeroPrices)
                .ToListAsync();

            return _mapper.Map<List<TierListSolution>>(solutionEntities);
        }

        public override async Task<TierListSolution> GetById(long id)
        {
            var solutionEntity = await _db.TierListSolutions
                .Include(s => s.Owner)
                .Include(s => s.HeroPrices)
                .FirstOrDefaultAsync(s => s.Id == id);

            return _mapper.Map<TierListSolution>(solutionEntity);
        }

        public async Task<IReadOnlyList<TierListSolution>> GetByTierListId(long id)
        {
            var solutionEntities = await _db.TierListSolutions
                .Where(s => s.TierList.Id == id)
                .Include(s => s.Owner)
                .Include(s => s.HeroPrices)
                .ToListAsync();

            return _mapper.Map<List<TierListSolution>>(solutionEntities);
        }

        public override async Task Update(TierListSolutionUpdateModel model)
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var existedSolution = await _db.TierListSolutions
                    .Include(x => x.HeroPrices)
                   .FirstOrDefaultAsync(s => s.Id == model.Id)
                   ?? throw new NotFoundException();

                if (existedSolution.OwnerId != model.AuthorId)
                {
                    throw new ForbiddenException("Нельзя изменять чужое решение!");
                }

                var entries = _db.ChangeTracker.Entries();

                _mapper.Map(model, existedSolution);

                if (model.HeroPrices is not null)
                {
                    await ValidateHeroes(existedSolution);

                    entries = _db.ChangeTracker.Entries();

                    _db.Heroes.AttachRange(existedSolution.HeroPrices.Select(x => x.Hero));
                }

                entries = _db.ChangeTracker.Entries();

                await _db.SaveChangesAsync();
            });
        }
    }
}
