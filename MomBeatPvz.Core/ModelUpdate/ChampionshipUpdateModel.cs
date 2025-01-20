using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.ModelUpdate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class ChampionshipUpdateModel : IUpdateModel<Championship, long>
    {
        public long Id { get; set; }

        public Trackable<string> Name { get; set; } = new();

        public Trackable<string> Description { get; set; } = new();

        public Trackable<ChampionshipStage> Stage { get; set; } = new();

        public Trackable<TierList?> TierList { get; set; } = new();

        public Trackable<DateTime?> StartDate { get; set; } = new();

        public Trackable<DateTime?> EndDate { get; set; } = new();

        public Trackable<List<Team>> Teams { get; set; } = new();

        public Trackable<List<Match>> Matches { get; set; } = new();

        public Trackable<List<Hero>> Heroes { get; set; } = new();
    }
}
