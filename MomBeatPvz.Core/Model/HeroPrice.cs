using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class HeroPrice
    {
        public Guid Id { get; set; }
        public Hero Hero { get; set; } = new();
        public int Value { get; set; }
        public TierListSolution Solution { get; set; } = new();
    }
}
