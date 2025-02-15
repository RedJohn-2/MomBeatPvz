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
    public class TeamUpdateModel : IUpdateModel<Team, long>
    {
        public long Id { get; set; }

        public long AuthorId { get; set; }

        public string? Name { get; set; }

        public List<Hero>? Heroes { get; set; }
    }
}
