using MomBeatPvz.Core.Model;
using MomBeatPvz.Persistence.Entities.Abstract;

namespace MomBeatPvz.Persistence.Entities
{
    public class HeroPriceEntity : IEntity<HeroPrice, Guid>
    {
        public Guid Id { get; set; }

        public HeroEntity Hero { get; set; } = new();

        public int Value { get; set; }

        public TierListSolutionEntity Solution { get; set; } = new();
    }
}
