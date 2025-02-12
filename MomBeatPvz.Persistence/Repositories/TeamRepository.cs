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
    public class TeamRepository :
        BaseRepository<Team, TeamCreateModel, TeamUpdateModel, TeamEntity, long>,
        ITeamStore
    {
        public TeamRepository(ApplicationContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public async override Task<Team> GetById(long id)
        {
            var existed = await _db.Teams
                .Include(t => t.Author)
                .Include(t => t.Heroes)
                .FirstOrDefaultAsync(x => x.Id!.Equals(id));

            return _mapper.Map<Team>(existed);
        }
    }
}
