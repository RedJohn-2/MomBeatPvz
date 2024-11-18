using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Interfaces
{
    public interface ITierListService
    {
        Task CreateAsync(TierListCreateModel model);

        Task UpdateAsync(TierListUpdateModel model);

        Task<TierList> GetByIdAsync(long id);
    }
}
