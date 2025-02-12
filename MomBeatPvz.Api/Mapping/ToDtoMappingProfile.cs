using AutoMapper;
using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.Match;
using MomBeatPvz.Api.Contracts.Team;
using MomBeatPvz.Api.Contracts.TierList;
using MomBeatPvz.Api.Contracts.TierListSolution;
using MomBeatPvz.Api.Contracts.User;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Persistence.Entities;

namespace MomBeatPvz.Api.Mapping
{
    public class ToDtoMappingProfile : Profile
    {
        public ToDtoMappingProfile()
        {
            CreateMap<Hero, HeroResponse>();

            CreateMap<User, UserResponse>();

            CreateMap<TierListSolution, TierListSolutionResponse>()
                .ForMember(dest => dest.TierListId, opt => opt.MapFrom(src => src.TierList.Id))
                .ForMember(dest => dest.Prices, opt => 
                                                opt.MapFrom(src => src.Prices
                                                .ToDictionary(
                                                    x => new HeroResponse(x.Hero.Id, x.Hero.Name, x.Hero.Url), 
                                                    x => x.Value)));

            CreateMap<TierList, TierListResponse>()
                .ForMember(dest => dest.ChampionshipId, opt => opt.MapFrom(src => src.Championship.Id));

            CreateMap<TierList, TierListRowResponse>()
                .ForMember(dest => dest.ChampionshipId, opt => opt.MapFrom(src => src.Championship.Id));

            CreateMap<Team, TeamResponse>()
                .ForMember(dest => dest.ChampionshipId, opt => opt.MapFrom(src => src.Championship.Id));

            CreateMap<Match, MatchResponse>()
                .ForMember(dest => dest.ChampionshipId, opt => opt.MapFrom(src => src.Championship.Id))
                .ForMember(dest => dest.Results, opt =>
                                                opt.MapFrom(src => src.Results
                                                .ToDictionary(
                                                    x => x.Team.Id,
                                                    x => x.Score)));
        }
    }
}
