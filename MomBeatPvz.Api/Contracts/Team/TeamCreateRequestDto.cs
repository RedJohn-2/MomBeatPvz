using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record TeamCreateRequestDto(
        string Name,
        int[] HeroIds,
        long ChampionshipId);
}
