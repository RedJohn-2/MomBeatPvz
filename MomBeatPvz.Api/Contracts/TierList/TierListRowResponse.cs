using MomBeatPvz.Api.Contracts.TierListSolution;
using MomBeatPvz.Api.Contracts.User;

namespace MomBeatPvz.Api.Contracts.TierList
{
    public record TierListRowResponse(
        long Id,
        string Name,
        string Description,
        TierListSolutionResponse Result,
        DateTime Created,
        long ChampionshipId);
}
