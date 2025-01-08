using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class Match
    {
        public long Id { get; set; }

        public Championship Championship { get; set; } = new();

        public bool IsCompleted { get; set; }

        public List<MatchResult> Results { get; set; } = new();
    }
}
