using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.ModelUpdate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelCreate
{
    public class TierListUpdateModel : IUpdateModel<TierList, long>
    {
        public long Id { get; set; }

        public Trackable<string> Name { get; set; } = new();

        public Trackable<string?> Description { get; set; } = new();

        public Trackable<int> MinPrice { get; set; } = new();

        public Trackable<int> MaxPrice { get; set; } = new();
    }
}
