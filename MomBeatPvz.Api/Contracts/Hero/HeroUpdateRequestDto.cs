using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record HeroUpdateRequestDto(
        int Id,
        string? Name,
        string? Url);
}
