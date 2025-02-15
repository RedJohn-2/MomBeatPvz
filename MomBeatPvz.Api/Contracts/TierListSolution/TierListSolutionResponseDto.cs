using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.User;
using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.TierListSolution
{
    public record TierListSolutionResponseDto(
        long Id,
        long TierListId,
        UserResponseDto Owner,
        Dictionary<HeroResponseDto, int> Prices);
}
