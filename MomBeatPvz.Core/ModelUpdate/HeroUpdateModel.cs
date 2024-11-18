using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelUpdate
{
    public record HeroUpdateModel
    {
        public int Id { get; set; }

        public Trackable<string> Name { get; set; } = new();

        public Trackable<string> Url { get; set; } = new();
    }
}
