using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Core.Exceptions;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Repositories
{
    public class TierListSolutionRepository : ITierListSolutionStore
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public TierListSolutionRepository(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Create(TierListSolutionCreateModel tierListSolution)
        {
            var solutionEntity = _mapper.Map<TierListSolutionEntity>(tierListSolution);

            await _db.AddAsync(solutionEntity);

            await _db.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            await _db.TierListSolutions
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<bool> Exist(long id)
        {
            return await _db.TierListSolutions
                .Where(s => s.Id == id)
                .AnyAsync();
        }

        public async Task<IReadOnlyList<TierListSolution>> GetAll()
        {
            var solutionEntities = await _db.TierListSolutions
                .Include(s => s.Owner)
                .Include(s => s.HeroPrices)
                .ToListAsync();

            return _mapper.Map<List<TierListSolution>>(solutionEntities);
        }

        public async Task<TierListSolution> GetById(long id)
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

        public async Task Update(TierListSolutionUpdateModel tierListSolution)
        {
            var existedSolution = await _db.TierListSolutions
                .FirstOrDefaultAsync(s => s.Id == tierListSolution.Id)
                ?? throw new NotFoundException();

            await _db.HeroPrices
                .Where(p => p.Solution == existedSolution)
                .ExecuteDeleteAsync();

            _mapper.Map(existedSolution, tierListSolution);

            await _db.SaveChangesAsync();
        }
    }
}
