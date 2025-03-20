using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class Championship : BaseLongModel
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int TeamPrice { get; set; }

        public ChampionshipStage Stage { get; set; }

        public ChampionshipFormat Format { get; set; }

        public TierList? TierList { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<Team> Teams { get; set; } = new();

        public List<Match> Matches { get; set; } = new();

        public List<Hero> Heroes { get; set; } = new();

        public User Creator { get; set; } = new();
    }
}
