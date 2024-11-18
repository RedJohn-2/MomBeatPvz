using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Interfaces
{
    public interface IHeroService
    {
        Task CreateAsync(HeroCreateModel model);

        Task UpdateAsync(HeroUpdateModel model);

        Task<Hero> GetByIdAsync(long id);

        Task<IReadOnlyList<Hero>> GetAllAsync();
    }
}
