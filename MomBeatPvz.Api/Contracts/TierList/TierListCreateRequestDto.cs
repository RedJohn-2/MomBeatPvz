using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record TierListCreateRequestDto(
        string Name,
        string Description,
        int MinPrice,
        int MaxPrice,
        long ChampionshipId);
}
