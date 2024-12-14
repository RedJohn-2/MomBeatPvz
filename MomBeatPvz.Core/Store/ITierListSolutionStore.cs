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
    public interface ITierListSolutionStore
    {
        Task Create(TierListSolutionCreateModel tierListSolution);

        Task Update(TierListSolutionUpdateModel tierListSolution);

        Task Delete(long id);

        Task<TierListSolution> GetById(long id);

        Task<IReadOnlyList<TierListSolution>> GetByTierListId(long id);

        Task<IReadOnlyList<TierListSolution>> GetAll();
    }
}
