using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class Team
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public User Author { get; set; } = new();

        public List<Hero> Heroes { get; set; } = new();

        public Championship Championship { get; set; } = new();
    }
}
