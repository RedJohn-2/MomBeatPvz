using MomBeatPvz.Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class TierList : BaseLongModel
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public List<TierListSolution> Solutions { get; set; } = new();

        public TierListSolution? Result { get; set; }

        public DateTime Created { get; set; }

        public Championship Championship { get; set; } = new();

        public User Creator { get; set; } = new();
    }
}
