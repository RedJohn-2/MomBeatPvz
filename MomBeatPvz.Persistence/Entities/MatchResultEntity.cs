using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Entities
{
    public class MatchResultEntity
    {
        public Guid Id { get; set; }

        public MatchEntity Match { get; set; } = new();

        public TeamEntity Team { get; set; } = new();

        public double Score { get; set; }
    }
}
