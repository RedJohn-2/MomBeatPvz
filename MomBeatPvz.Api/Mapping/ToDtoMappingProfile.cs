using AutoMapper;
using MomBeatPvz.Api.Contracts.Championship;
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
            CreateMap<Hero, HeroResponseDto>();

            CreateMap<User, UserResponseDto>();

            CreateMap<TierListSolution, TierListSolutionResponseDto>()
                .ForMember(dest => dest.TierListId, opt => opt.MapFrom(src => src.TierList.Id))
                .ForMember(dest => dest.Prices, opt => 
                                                opt.MapFrom(src => src.Prices
                                                .ToDictionary(
                                                    x => new HeroResponseDto(x.Hero.Id, x.Hero.Name, x.Hero.Url), 
                                                    x => x.Value)));

            CreateMap<TierList, TierListResponseDto>()
                .ForMember(dest => dest.ChampionshipId, opt => opt.MapFrom(src => src.Championship.Id))
                .ForMember(dest => dest.Heroes, opt =>
                                                opt.MapFrom(src => src.Championship.Heroes
                                                .Select(x => new HeroResponseDto(x.Id, x.Name, x.Url)).ToArray()));

            CreateMap<TierList, TierListRowResponseDto>();

            CreateMap<TierList, TierListMainInfoResponseDto>()
                .ForMember(dest => dest.ChampionshipId, opt => opt.MapFrom(src => src.Championship.Id));

            CreateMap<Team, TeamResponseDto>()
                .ForMember(dest => dest.ChampionshipId, opt => opt.MapFrom(src => src.Championship.Id));

            CreateMap<Match, MatchResponseDto>()
                .ForMember(dest => dest.ChampionshipId, opt => opt.MapFrom(src => src.Championship.Id))
                .ForMember(dest => dest.Results, opt =>
                                                opt.MapFrom(src => src.Results
                                                .ToDictionary(
                                                    x => x.Team.Id,
                                                    x => x.Score)));

            CreateMap<Championship, ChampionshipResponseDto>();

            CreateMap<Championship, ChampionshipRowResponseDto>();
        }
    }
}
