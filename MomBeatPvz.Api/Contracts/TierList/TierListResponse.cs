using MomBeatPvz.Api.Contracts.TierListSolution;
using MomBeatPvz.Api.Contracts.User;

namespace MomBeatPvz.Api.Contracts.TierList
{
    public record TierListResponse(
        long Id,
        string Name,
        string Description,
        int MinPrice,
        int MaxPrice,
        List<TierListSolutionResponse> Solutions,
        TierListSolutionResponse Result,
        DateTime Created,
        long ChampionshipId,
        UserResponse Creator);
}
