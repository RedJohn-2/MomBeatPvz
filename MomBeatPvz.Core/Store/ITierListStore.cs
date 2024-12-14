using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Store
{
    public interface ITierListStore
    {
        Task Create(TierListCreateModel tierList);

        Task Update(TierListUpdateModel tierList);

        Task Delete(long id);

        Task<TierList> GetById(long id);

        Task<IReadOnlyList<TierList>> GetByName(string name);

        Task<IReadOnlyList<TierList>> GetAll();

    }
}
