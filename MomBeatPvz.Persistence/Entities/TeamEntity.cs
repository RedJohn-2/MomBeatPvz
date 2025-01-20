using MomBeatPvz.Core.Model;
using MomBeatPvz.Persistence.Entities.Abstract;

namespace MomBeatPvz.Persistence.Entities
{
    public class TeamEntity : IEntity<Team, long>
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public UserEntity Author { get; set; } = new();

        public List<HeroEntity> Heroes { get; set; } = new();

        public ChampionshipEntity Championship { get; set; } = new();
    }
}
