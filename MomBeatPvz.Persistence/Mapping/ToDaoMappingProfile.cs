using AutoMapper;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Mapping
{
    public class ToDaoMappingProfile : Profile
    {
        public ToDaoMappingProfile()
        {
            CreateMap<HeroCreateModel, HeroEntity>();
            CreateMap<HeroUpdateModel, HeroEntity>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.PreCondition(src => src.Name.IsTracked);
                    opt.MapFrom(src => src.Name.Value);
                })
                .ForMember(dest => dest.Url, opt =>
                {
                    opt.PreCondition(src => src.Url.IsTracked);
                    opt.MapFrom(src => src.Url.Value);
                });

            CreateMap<User, UserEntity>();

            CreateMap<TierListSolutionCreateModel, TierListSolutionEntity>();
            CreateMap<TierListSolutionUpdateModel, TierListSolutionEntity>()
                .ForMember(dest => dest.HeroPrices, opt =>
                {
                    opt.PreCondition(src => src.HeroPrices.IsTracked);
                    opt.MapFrom(src => src.HeroPrices.Value);
                });

            CreateMap<TierListCreateModel, TierListEntity>();
            CreateMap<TierListUpdateModel, TierListEntity>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.PreCondition(src => src.Name.IsTracked);
                    opt.MapFrom(src => src.Name.Value);
                })
                .ForMember(dest => dest.Description, opt =>
                {
                    opt.PreCondition(src => src.Description.IsTracked);
                    opt.MapFrom(src => src.Description.Value);
                })
                .ForMember(dest => dest.MinPrice, opt =>
                {
                    opt.PreCondition(src => src.MinPrice.IsTracked);
                    opt.MapFrom(src => src.MinPrice.Value);
                })
                .ForMember(dest => dest.MaxPrice, opt =>
                {
                    opt.PreCondition(src => src.MaxPrice.IsTracked);
                    opt.MapFrom(src => src.MaxPrice.Value);
                });

            CreateMap<HeroPrice, HeroPriceEntity>();
        }
    }
}
