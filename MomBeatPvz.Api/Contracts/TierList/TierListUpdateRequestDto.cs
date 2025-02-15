using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record TierListUpdateRequestDto(
        long Id,
        string? Name,
        string? Description,
        Trackable<int>? MinPrice,
        Trackable<int>? MaxPrice);
}
