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
                    opt.PreCondition(src => src.Name is not null);
                    opt.MapFrom(src => src.Name);
                })
                .ForMember(dest => dest.Url, opt =>
                {
                    opt.PreCondition(src => src.Url is not null);
                    opt.MapFrom(src => src.Url);
                });

            CreateMap<User, UserEntity>();
            CreateMap<UserUpdateModel, UserEntity>();

            CreateMap<TierListSolutionCreateModel, TierListSolutionEntity>();
            CreateMap<TierListSolutionUpdateModel, TierListSolutionEntity>()
                .ForMember(dest => dest.HeroPrices, opt =>
                {
                    opt.PreCondition(src => src.HeroPrices is not null);
                    opt.MapFrom(src => src.HeroPrices);
                });

            CreateMap<TierListCreateModel, TierListEntity>();
            CreateMap<TierListUpdateModel, TierListEntity>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.PreCondition(src => src.Name is not null);
                    opt.MapFrom(src => src.Name);
                })
                .ForMember(dest => dest.Description, opt =>
                {
                    opt.PreCondition(src => src.Description is not null);
                    opt.MapFrom(src => src.Description);
                })
                .ForMember(dest => dest.MinPrice, opt =>
                {
                    opt.PreCondition(src => src.MinPrice is not null);
                    opt.MapFrom(src => src.MinPrice!.Value);
                })
                .ForMember(dest => dest.MaxPrice, opt =>
                {
                    opt.PreCondition(src => src.MaxPrice is not null);
                    opt.MapFrom(src => src.MaxPrice!.Value);
                });

            CreateMap<TeamCreateModel, TeamEntity>();
            CreateMap<TeamUpdateModel, TeamEntity>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.PreCondition(src => src.Name is not null);
                    opt.MapFrom(src => src.Name);
                })
                .ForMember(dest => dest.Heroes, opt =>
                {
                    opt.PreCondition(src => src.Heroes is not null);
                    opt.MapFrom(src => src.Heroes);
                });

            CreateMap<MatchCreateModel, MatchEntity>();
            CreateMap<MatchUpdateModel, MatchEntity>()
                .ForMember(dest => dest.IsCompleted, opt =>
                {
                    opt.PreCondition(src => src.IsCompleted is not null);
                    opt.MapFrom(src => src.IsCompleted!.Value);
                })
                .ForMember(dest => dest.Results, opt =>
                {
                    opt.PreCondition(src => src.Results is not null);
                    opt.MapFrom(src => src.Results);
                });

            CreateMap<ChampionshipCreateModel, ChampionshipEntity>();
            CreateMap<ChampionshipUpdateModel, ChampionshipEntity>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.PreCondition(src => src.Name is not null);
                    opt.MapFrom(src => src.Name);
                })
                .ForMember(dest => dest.Description, opt =>
                {
                    opt.PreCondition(src => src.Description is not null);
                    opt.MapFrom(src => src.Description);
                })
                .ForMember(dest => dest.Stage, opt =>
                {
                    opt.PreCondition(src => src.Stage is not null);
                    opt.MapFrom(src => src.Stage!.Value);
                })
                .ForMember(dest => dest.StartDate, opt =>
                {
                    opt.PreCondition(src => src.StartDate is not null);
                    opt.MapFrom(src => src.StartDate!.Value);
                })
                .ForMember(dest => dest.EndDate, opt =>
                {
                    opt.PreCondition(src => src.EndDate is not null);
                    opt.MapFrom(src => src.EndDate!.Value);
                })
                .ForMember(dest => dest.Teams, opt =>
                {
                    opt.PreCondition(src => src.Teams is not null);
                    opt.MapFrom(src => src.Teams);
                })
                .ForMember(dest => dest.Matches, opt =>
                {
                    opt.PreCondition(src => src.Matches is not null);
                    opt.MapFrom(src => src.Matches);
                })
                .ForMember(dest => dest.Heroes, opt =>
                {
                    opt.PreCondition(src => src.Heroes is not null);
                    opt.MapFrom(src => src.Heroes);
                });

            CreateMap<HeroPrice, HeroPriceEntity>();
            CreateMap<MatchResult, MatchResultEntity>();

        }
    }
}
