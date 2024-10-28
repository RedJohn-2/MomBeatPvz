using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvzDichTierList.Core.Model
{
    public class TierListSolution
    {
        public long Id { get; set; }      
        public TierList TierList { get; set; } = new();
        public User Owner { get; set; } = new();
        public List<HeroPrice> Prices { get; set; } = new();

    }
}
