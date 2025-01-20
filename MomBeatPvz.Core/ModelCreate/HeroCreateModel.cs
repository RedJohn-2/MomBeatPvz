using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelCreate
{
    public class HeroCreateModel : ICreateModel<Hero>
    {
        public string Name { get; set; } = string.Empty;

        public string Url {  get; set; } = string.Empty;

    }
}
