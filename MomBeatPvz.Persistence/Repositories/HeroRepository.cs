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
    public class HeroRepository : 
        BaseRepository<Hero, HeroCreateModel, HeroUpdateModel, HeroEntity, int>, 
        IHeroStore
    {
        public HeroRepository(ApplicationContext db, IMapper mapper, IUnitOfWork unitOfWork) : base(db, mapper, unitOfWork)
        {

        }
    }
}
