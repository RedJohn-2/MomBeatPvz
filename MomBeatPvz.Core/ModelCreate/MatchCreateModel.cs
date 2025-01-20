using MomBeatPvz.Core.ModelCreate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class MatchCreateModel : ICreateModel<Match>
    {
        public Championship Championship { get; set; } = new();
    }
}
