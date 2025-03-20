using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Contracts.Championship
{
    public record ChampionshipCreateRequestDto(
        string Name,
        string Description,
        int TeamPrice,
        ChampionshipFormat Format,
        DateTime? StartDate,
        DateTime? EndDate,
        int[] HeroIds);
}
