using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public TierListSolutionRepository(ApplicationContext db, IMapper mapper) : base(db, mapper)
        {
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
            var existedSolution = await _db.TierListSolutions
                .FirstOrDefaultAsync(s => s.Id == model.Id)
                ?? throw new NotFoundException();

            await _db.HeroPrices
                .Where(p => p.Solution == existedSolution)
                .ExecuteDeleteAsync();

            _mapper.Map(model, existedSolution);

            await _db.SaveChangesAsync();
        }
    }
}
