using PvzDichTierList.Core.Model;
using PvzDichTierList.Core.ModelUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvzDichTierList.Core.ModelCreate
{
    public record TierListUpdateModel
    {
        public long Id { get; set; }
        public Changed<string> Name { get; init; } = new();
        public Changed<string?> Description { get; set; } = new();
        public Changed<int> MinPrice { get; set; } = new();
        public Changed<int> MaxPrice { get; set; } = new();
    }
}
