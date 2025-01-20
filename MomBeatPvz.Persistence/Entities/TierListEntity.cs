using MomBeatPvz.Core.Model;
using MomBeatPvz.Persistence.Entities.Abstract;

namespace MomBeatPvz.Persistence.Entities
{
    public class TierListEntity : IEntity<TierList, long>
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public List<TierListSolutionEntity> Solutions { get; set; } = new();

        public TierListSolutionEntity Result { get; set; } = new();

        public DateTime Created { get; set; }

        public UserEntity Creator { get; set; } = new();

        public ChampionshipEntity Championship { get; set; } = new();
    }
}
