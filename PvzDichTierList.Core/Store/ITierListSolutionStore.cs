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
    public interface ITierListSolutionStore
    {
        Task Create(TierListSolutionCreateModel tierListSolution);

        Task Update(TierListSolutionUpdateModel tierListSolution);

        Task Delete(long id);

        Task<TierListSolution> GetById(long id);

        Task<IReadOnlyList<TierListSolution>> GetAll();
    }
}
