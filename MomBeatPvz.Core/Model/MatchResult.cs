using MomBeatPvz.Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class MatchResult : BaseGuidModel
    {
        public Match Match { get; set; } = new();

        public Team Team { get; set; } = new();

        public double Score { get; set; }
    }
}
