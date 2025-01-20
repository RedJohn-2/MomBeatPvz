using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.ModelCreate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class ChampionshipCreateModel : ICreateModel<Championship>
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ChampionshipFormat Format { get; set; }

        public TierList? TierList { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<Hero> Heroes { get; set; } = new();

        public User Creator { get; set; } = new();
    }
}
