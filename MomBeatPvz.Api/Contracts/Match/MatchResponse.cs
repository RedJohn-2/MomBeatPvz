using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.Match
{
    public record MatchResponse(
        long Id,
        long ChampionshipId,
        bool IsCompleted,
        Dictionary<long, double> Results);
}
