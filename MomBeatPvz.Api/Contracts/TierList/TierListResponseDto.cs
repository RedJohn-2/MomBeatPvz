using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.TierListSolution;
using MomBeatPvz.Api.Contracts.User;

namespace MomBeatPvz.Api.Contracts.TierList
{
    public class TierListResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public HeroResponseDto[] Heroes { get; set; } = [];
        public DateTime Created { get; set; }
        public long ChampionshipId { get; set; }
        public UserResponseDto Creator { get; set; } = null!;
    }
}
