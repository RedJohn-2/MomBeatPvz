using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelCreate
{
    public record TierListCreateModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public DateTime Created { get; set; }
        public User Creator { get; set; } = new();
    }
}
