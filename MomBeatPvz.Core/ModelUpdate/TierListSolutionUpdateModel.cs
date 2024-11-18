using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelUpdate
{
    public record TierListSolutionUpdateModel
    {
        public long Id { get; set; }
        public Trackable<List<HeroPrice>> HeroPrices { get; set; } = new();
    }
}
