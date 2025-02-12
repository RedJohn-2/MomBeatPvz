using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.User;
using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.Team
{
    public record TeamResponse(
        long Id,
        string Name,
        UserResponse Author,
        HeroResponse[] Heroes,
        long ChampionshipId);
}
