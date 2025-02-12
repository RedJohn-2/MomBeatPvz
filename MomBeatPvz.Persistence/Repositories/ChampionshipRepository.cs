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
    public class ChampionshipRepository :
        BaseRepository<Championship, ChampionshipCreateModel, ChampionshipUpdateModel, ChampionshipEntity, long>,
        IChampionshipStore
    {
        public ChampionshipRepository(ApplicationContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public async override Task<Championship> GetById(long id)
        {
            var existed = await _db.Championships
                .Include(c => c.TierList)
                .Include(c => c.Creator)
                .Include(c => c.Heroes)
                .Include(c => c.Matches)
                .Include(c => c.Teams)
                .FirstOrDefaultAsync(x => x.Id!.Equals(id));

            return _mapper.Map<Championship>(existed);
        }
    }
}
