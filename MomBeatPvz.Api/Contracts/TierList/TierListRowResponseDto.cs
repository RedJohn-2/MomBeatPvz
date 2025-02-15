using MomBeatPvz.Api.Contracts.TierListSolution;
using MomBeatPvz.Api.Contracts.User;

namespace MomBeatPvz.Api.Contracts.TierList
{
    public record TierListRowResponseDto(
        long Id,
        string Name,
        string Description,
        TierListSolutionResponseDto Result,
        DateTime Created,
        long ChampionshipId);
}
