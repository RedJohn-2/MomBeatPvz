using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Entities
{
    public class MatchEntity
    {
        public long Id { get; set; }

        public ChampionshipEntity Championship { get; set; } = new();

        public bool IsCompleted { get; set; }

        public List<MatchResultEntity> Results { get; set; } = new();
    }
}
