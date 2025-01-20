using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelUpdate
{
    public class TierListSolutionUpdateModel : IUpdateModel<TierListSolution, long>
    {
        public long Id { get; set; }

        public Trackable<List<HeroPrice>> HeroPrices { get; set; } = new();
    }
}
