using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.Match
{
    public record MatchResponseDto(
        long Id,
        long ChampionshipId,
        bool IsCompleted,
        Dictionary<long, double> Results);
}
