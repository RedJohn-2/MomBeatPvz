using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Core.Exceptions;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Persistence.Entities;
using MomBeatPvz.Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MomBeatPvz.Persistence.Repositories
{
    public class TierListRepository : 
        BaseRepository<TierList, TierListCreateModel, TierListUpdateModel, TierListEntity, long>
        ITierListStore
    {
        public TierListRepository(ApplicationContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<IReadOnlyList<TierList>> GetAll()
        {
            var existedTierLists = await _db.TierLists
                .Include(t => t.Creator)
                .ToListAsync();

            return _mapper.Map<IReadOnlyList<TierList>>(existedTierLists);
        }

        public override async Task<TierList> GetById(long id)
        {
            var existedTierList = await _db.TierLists
                .Include(t => t.Creator)
                .FirstOrDefaultAsync(t => t.Id == id);

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
    }
}
