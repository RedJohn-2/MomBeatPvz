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
    }
}
