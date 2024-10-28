using PvzDichTierList.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvzDichTierList.Core.ModelCreate
{
    public record TierListSolutionCreateModel
    {
        public TierList TierList { get; set; } = new();
        public User Owner { get; set; } = new();
        public List<HeroPrice> HeroPrices { get; set; } = new();
    }
}
