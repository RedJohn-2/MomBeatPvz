using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record ChampionshipUpdateRequestDto(
        long Id,
        string? Name,
        string? Description,
        int? TeamPrice,
        ChampionshipStage? Stage,
        Trackable<DateTime?>? StartDate,
        Trackable<DateTime?>? EndDate,
        long[]? TeamIds,
        long[]? MatchIds,
        int[]? HeroIds);
}
