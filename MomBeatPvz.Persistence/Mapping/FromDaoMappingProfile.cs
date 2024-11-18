using AutoMapper;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Mapping
{
    public class FromDaoMappingProfile : Profile
    {
        public FromDaoMappingProfile() 
        {
            CreateMap<UserEntity, User>();

            CreateMap<HeroEntity, Hero>();

            CreateMap<TierListSolutionEntity, TierListSolution>();

            CreateMap<TierListEntity, TierList>();

            CreateMap<HeroPriceEntity, HeroPrice>();
        }  
    }
}
