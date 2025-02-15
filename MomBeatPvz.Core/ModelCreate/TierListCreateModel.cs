using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate.Abstract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelCreate
{
    public record TierListCreateModel : ICreateModel<TierList>
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public DateTime Created { get; set; }

        public Championship Championship { get; set; } = new();

        public User Creator { get; set; } = new();
    }
}
