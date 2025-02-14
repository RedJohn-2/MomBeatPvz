using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record ChampionshipUpdateRequestDto(
        long Id,
        Trackable<string> Name,
        Trackable<string> Description,
        Trackable<ChampionshipStage> Stage,
        Trackable<DateTime?> StartDate,
        Trackable<DateTime?> EndDate,
        int[] HeroIds);

    public Trackable<TierList?> TierList { get; set; } = new();

    public Trackable<DateTime?> StartDate { get; set; } = new();

    public Trackable<DateTime?> EndDate { get; set; } = new();

    public Trackable<List<Team>> Teams { get; set; } = new();

    public Trackable<List<Match>> Matches { get; set; } = new();

    public Trackable<List<Hero>> Heroes { get; set; } = new();
}
