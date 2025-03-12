using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelUpdate
{
    public class MatchUpdateModel : IUpdateModel<Match, long>
    {
        public long Id { get; set; }

        public bool? IsCompleted { get; set; }

        public List<MatchResult>? Results { get; set; }
    }
}
