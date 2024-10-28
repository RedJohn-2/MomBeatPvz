using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvzDichTierList.Core.ModelUpdate
{
    public record HeroUpdateModel
    {
        public int Id { get; set; }

        public Changed<string> Name { get; set; } = new();

        public Changed<string> Url { get; set; } = new();
    }
}
