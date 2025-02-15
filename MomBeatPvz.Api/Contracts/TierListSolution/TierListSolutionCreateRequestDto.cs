using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record TierListSolutionCreateRequestDto(
        long TierListId,
        long OwnerId,
        Dictionary<int, int> HeroPrices);
}
