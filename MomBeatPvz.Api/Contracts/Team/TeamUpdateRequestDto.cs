using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record TeamUpdateRequestDto(
        long Id,
        string? Name,
        int[]? HeroIds);
}
