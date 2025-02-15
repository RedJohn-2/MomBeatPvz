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

        public long AuthorId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public Trackable<int>? MinPrice { get; set; }

        public Trackable<int>? MaxPrice { get; set; }
    }
}
