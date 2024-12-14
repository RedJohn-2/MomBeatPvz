using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Interfaces
{
    public interface ITierListSolutionService
    {
        Task CreateAsync(TierListSolutionCreateModel model);

        Task UpdateAsync(TierListSolutionUpdateModel model);

        Task DeleteAsync(long id);

        Task<TierListSolution> GetByIdAsync(long id);

        Task<IReadOnlyList<TierListSolution>> GetAllAsync();

        Task<IReadOnlyList<TierListSolution>> GetByTierListIdAsync(long id);
    }
}
