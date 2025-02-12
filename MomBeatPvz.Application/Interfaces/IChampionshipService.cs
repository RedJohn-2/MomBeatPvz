using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Interfaces
{
    public interface IChampionshipService
    {
        Task CreateAsync(ChampionshipCreateModel model);

        Task UpdateAsync(ChampionshipUpdateModel model);

        Task<Championship> GetByIdAsync(long id);
    }
}
