using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.User;
using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.TierListSolution
{
    public record TierListSolutionResponse(
        long Id,
        long TierListId,
        UserResponse Owner,
        Dictionary<HeroResponse, int> Prices);
}
