using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record TierListSolutionUpdateRequestDto(
        long Id,
        Dictionary<int, int>? HeroPrices);
}
