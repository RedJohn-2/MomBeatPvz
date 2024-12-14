using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Store
{
    public interface IHeroStore
    {
        Task Create(HeroCreateModel hero);

        Task Update(HeroUpdateModel hero);

        Task Delete(int id);

        Task<Hero> GetById(int id);

        Task<IReadOnlyList<Hero>> GetAll();

        Task<bool> Exist(int id);

    }
}
