using AutoMapper;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Persistence.Entities;

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
            CreateMap<UserUpdateModel, UserEntity>();

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

            CreateMap<TeamCreateModel, TeamEntity>();
            CreateMap<TeamUpdateModel, TeamEntity>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.PreCondition(src => src.Name.IsTracked);
                    opt.MapFrom(src => src.Name.Value);
                })
                .ForMember(dest => dest.Heroes, opt =>
                {
                    opt.PreCondition(src => src.Heroes.IsTracked);
                    opt.MapFrom(src => src.Heroes.Value);
                });

            CreateMap<MatchCreateModel, MatchEntity>();
            CreateMap<MatchUpdateModel, MatchEntity>()
                .ForMember(dest => dest.IsCompleted, opt =>
                {
                    opt.PreCondition(src => src.IsCompleted.IsTracked);
                    opt.MapFrom(src => src.IsCompleted.Value);
                })
                .ForMember(dest => dest.Results, opt =>
                {
                    opt.PreCondition(src => src.Results.IsTracked);
                    opt.MapFrom(src => src.Results.Value);
                });

            CreateMap<ChampionshipCreateModel, ChampionshipEntity>();
            CreateMap<ChampionshipUpdateModel, ChampionshipEntity>()
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
                .ForMember(dest => dest.TierList, opt =>
                {
                    opt.PreCondition(src => src.TierList.IsTracked);
                    opt.MapFrom(src => src.TierList.Value);
                })
                .ForMember(dest => dest.Stage, opt =>
                {
                    opt.PreCondition(src => src.Stage.IsTracked);
                    opt.MapFrom(src => src.Stage.Value);
                })
                .ForMember(dest => dest.StartDate, opt =>
                {
                    opt.PreCondition(src => src.StartDate.IsTracked);
                    opt.MapFrom(src => src.StartDate.Value);
                })
                .ForMember(dest => dest.EndDate, opt =>
                {
                    opt.PreCondition(src => src.EndDate.IsTracked);
                    opt.MapFrom(src => src.EndDate.Value);
                })
                .ForMember(dest => dest.Teams, opt =>
                {
                    opt.PreCondition(src => src.Teams.IsTracked);
                    opt.MapFrom(src => src.Teams.Value);
                })
                .ForMember(dest => dest.Matches, opt =>
                {
                    opt.PreCondition(src => src.Matches.IsTracked);
                    opt.MapFrom(src => src.Matches.Value);
                })
                .ForMember(dest => dest.Heroes, opt =>
                {
                    opt.PreCondition(src => src.Heroes.IsTracked);
                    opt.MapFrom(src => src.Heroes.Value);
                });

            CreateMap<HeroPrice, HeroPriceEntity>();
            CreateMap<MatchResult, MatchResultEntity>();

        }
    }
}
