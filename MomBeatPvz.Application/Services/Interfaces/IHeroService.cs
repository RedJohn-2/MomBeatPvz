using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services.Interfaces
{
    public interface IHeroService : 
        IService<Hero, HeroCreateModel, HeroUpdateModel, int>
    {
        void CheckDuplicates(List<Hero> heroes);
    }
}
