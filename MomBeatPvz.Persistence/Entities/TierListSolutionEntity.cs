using MomBeatPvz.Core.Model;
using MomBeatPvz.Persistence.Entities.Abstract;

namespace MomBeatPvz.Persistence.Entities
{
    public class TierListSolutionEntity : IEntity<TierListSolution, long>
    {
        public long Id { get; set; }

        public TierListEntity TierList { get; set; } = new();

        public UserEntity Owner { get; set; } = new();

        public List<HeroPriceEntity> HeroPrices { get; set; } = new();

        public long TierListId { get; set; }

        public long OwnerId { get; set; }
    }
}
