using PvzDichTierList.Core.Model;
using PvzDichTierList.Core.ModelCreate;
using PvzDichTierList.Core.ModelUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvzDichTierList.Core.Store
{
    public interface IHeroStore
    {
        Task Create(HeroCreateModel hero);

        Task Update(HeroUpdateModel hero);

        Task Delete(int id);

        Task<Hero> GetById(int id);

        Task<IReadOnlyList<Hero>> GetAll();

    }
}
