using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Entities
{
    public class TierListSolutionEntity
    {
        public long Id { get; set; }
        public TierListEntity TierList { get; set; } = new();
        public UserEntity Owner { get; set; } = new();
        public List<HeroPriceEntity> HeroPrices { get; set; } = new();
    }
}
