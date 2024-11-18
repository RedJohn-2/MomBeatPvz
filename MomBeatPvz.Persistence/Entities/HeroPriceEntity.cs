using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Entities
{
    public class HeroPriceEntity
    {
        public Guid Id { get; set; }
        public HeroEntity Hero { get; set; } = new();
        public int Value { get; set; }
        public TierListSolutionEntity Solution { get; set; } = new();
    }
}
