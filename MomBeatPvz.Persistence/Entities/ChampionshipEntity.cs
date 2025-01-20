using MomBeatPvz.Core.Enums;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Persistence.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Entities
{
    public class ChampionshipEntity : IEntity<Championship, long>
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ChampionshipStage Stage { get; set; }

        public ChampionshipFormat Format { get; set; }

        public TierListEntity? TierList { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<TeamEntity> Teams { get; set; } = new();

        public List<MatchEntity> Matches { get; set; } = new();

        public List<HeroEntity> Heroes { get; set; } = new();

        public UserEntity Creator { get; set; } = new();
    }
}
