using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.Match;
using MomBeatPvz.Api.Contracts.Team;
using MomBeatPvz.Api.Contracts.TierList;
using MomBeatPvz.Api.Contracts.User;
using MomBeatPvz.Core.Enums;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record ChampionshipRowResponseDto(
        long Id,
        string Name,
        string Description,
        int TeamPrice,
        ChampionshipStage Stage,
        ChampionshipFormat Format,
        DateTime? StartDate,
        DateTime? EndDate,
        UserResponseDto Creator);
}
