using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.Match;
using MomBeatPvz.Api.Contracts.Team;
using MomBeatPvz.Api.Contracts.TierList;
using MomBeatPvz.Api.Contracts.User;
using MomBeatPvz.Core.Enums;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record ChampionshipResponse(
        long Id,
        string Name,
        string Description,
        ChampionshipStage Stage,
        ChampionshipFormat Format,
        TierListRowResponse TierList,
        DateTime? StartDate,
        DateTime? EndDate,
        TeamResponse[] Teams,
        MatchResponse[] Matches,
        HeroResponse[] Heroes,
        UserResponse Creator
        );
}
