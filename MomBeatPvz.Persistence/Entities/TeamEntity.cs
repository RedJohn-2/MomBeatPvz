using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Entities
{
    public class TeamEntity
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public UserEntity Author { get; set; } = new();

        public List<HeroEntity> Heroes { get; set; } = new();

        public ChampionshipEntity Championship { get; set; } = new();
    }
}
