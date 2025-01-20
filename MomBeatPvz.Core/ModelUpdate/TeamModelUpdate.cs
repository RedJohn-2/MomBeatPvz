using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.ModelUpdate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class TeamModelUpdate : IUpdateModel<Team, long>
    {
        public long Id { get; set; }

        public Trackable<string> Name { get; set; } = new();

        public Trackable<List<Hero>> Heroes { get; set; } = new();
    }
}
