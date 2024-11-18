using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Entities
{
    public class TierListEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public List<TierListSolutionEntity> Solutions { get; set; } = new();
        public TierListSolutionEntity Result { get; set; } = new();
        public DateTime Created { get; set; }
        public UserEntity Creator { get; set; } = new();
    }
}
