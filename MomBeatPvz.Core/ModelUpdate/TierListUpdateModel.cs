using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelCreate
{
    public record TierListUpdateModel
    {
        public long Id { get; set; }
        public Trackable<string> Name { get; set; } = new();
        public Trackable<string?> Description { get; set; } = new();
        public Trackable<int> MinPrice { get; set; } = new();
        public Trackable<int> MaxPrice { get; set; } = new();
    }
}
