using MomBeatPvz.Api.Contracts.TierListSolution;
using MomBeatPvz.Api.Contracts.User;

namespace MomBeatPvz.Api.Contracts.TierList
{
    public record TierListResponseDto(
        long Id,
        string Name,
        string Description,
        int MinPrice,
        int MaxPrice,
        List<TierListSolutionResponseDto> Solutions,
        TierListSolutionResponseDto Result,
        DateTime Created,
        long ChampionshipId,
        UserResponseDto Creator);
}
