using MomBeatPvz.Core.Model;
using MomBeatPvz.Persistence.Entities.Abstract;

namespace MomBeatPvz.Persistence.Entities
{
    public class MatchEntity : IEntity<Match, long>
    {
        public long Id { get; set; }

        public ChampionshipEntity Championship { get; set; } = new();

        public bool IsCompleted { get; set; }

        public List<MatchResultEntity> Results { get; set; } = new();
    }
}
