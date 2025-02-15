using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.User;
using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.Team
{
    public record TeamResponseDto(
        long Id,
        string Name,
        UserResponseDto Author,
        HeroResponseDto[] Heroes,
        long ChampionshipId);
}
