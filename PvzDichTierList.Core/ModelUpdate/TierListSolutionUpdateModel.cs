using PvzDichTierList.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvzDichTierList.Core.ModelUpdate
{
    public record TierListSolutionUpdateModel
    {
        public long Id { get; set; }
        public Changed<List<HeroPrice>> HeroPrices { get; set; } = new();
    }
}
