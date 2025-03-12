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

        public long AuthorId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public ChampionshipStage? Stage { get; set; }

        public Trackable<DateTime?>? StartDate { get; set; }

        public Trackable<DateTime?>? EndDate { get; set; }

        public List<Team>? Teams { get; set; }

        public List<Match>? Matches { get; set; }

        public List<Hero>? Heroes { get; set; }
    }
}
