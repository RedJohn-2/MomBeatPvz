using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record TierListSolutionCreateRequestDto(
        long TierListId,
        Dictionary<int, int> HeroPrices);
}
