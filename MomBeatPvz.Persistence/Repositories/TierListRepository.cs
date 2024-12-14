using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MomBeatPvz.Persistence.Repositories
{
    public class TierListRepository : ITierListStore
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public TierListRepository(ApplicationContext db, IMapper mapper)
        { 
            _db = db;
            _mapper = mapper;
        }

        public async Task Create(TierListCreateModel tierList)
        {
            var tierListEntity = _mapper.Map<TierListEntity>(tierList);

            await _db.AddAsync(tierListEntity);

            await _db.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            await _db.TierLists
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<bool> Exist(long id)
        {
            return await _db.TierLists
                .Where(t => t.Id == id)
                .AnyAsync();
        }

        public async Task<IReadOnlyList<TierList>> GetAll()
        {
            var existedTierLists = await _db.TierLists
                .Include(t => t.Creator)
                .ToListAsync();

            return _mapper.Map<IReadOnlyList<TierList>>(existedTierLists);
        }

        public async Task<TierList> GetById(long id)
        {
            var existedTierList = await _db.TierLists
                .Include(t => t.Creator)
                .FirstOrDefaultAsync(t => t.Id == id)
                ?? throw new Exception();

            return _mapper.Map<TierList>(existedTierList);
        }

        public async Task<IReadOnlyList<TierList>> GetByName(string name)
        {
            var existedTierLists = await _db.TierLists
                .Include(t => t.Creator)
                .Where(t => t.Name == name)
                .ToListAsync();

            return _mapper.Map<IReadOnlyList<TierList>>(existedTierLists);
        }

        public async Task Update(TierListUpdateModel tierList)
        {
            var existedTierList = await _db.TierLists
                .FirstOrDefaultAsync(t => t.Id == tierList.Id)
                ?? throw new Exception();

            _mapper.Map(tierList, existedTierList);

            await _db.SaveChangesAsync();
        }
    }
}
