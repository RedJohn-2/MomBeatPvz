using PvzDichTierList.Core.Model;
using PvzDichTierList.Core.ModelCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvzDichTierList.Core.Store
{
    public interface ITierListStore
    {
        Task Create(TierListCreateModel tierList);

        Task Update(TierListUpdateModel tierList);

        Task Delete(long id);

        Task<TierList> GetById();

        Task<IReadOnlyList<TierList>> GetByName(string name);

    }
}
