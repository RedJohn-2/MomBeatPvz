using MomBeatPvz.Core.Model;
using MomBeatPvz.Persistence.Entities.Abstract;

namespace MomBeatPvz.Persistence.Entities
{
    public class MatchResultEntity : IEntity<MatchResult, Guid>
    {
        public Guid Id { get; set; }

        public MatchEntity Match { get; set; } = new();

        public TeamEntity Team { get; set; } = new();

        public double Score { get; set; }
    }
}
