using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services.Interfaces
{
    public interface ITierListSolutionService :
        IService<TierListSolution, TierListSolutionCreateModel, TierListSolutionUpdateModel, long>
    {
        Task<IReadOnlyList<TierListSolution>> GetAllAsync();

        Task<IReadOnlyList<TierListSolution>> GetByTierListIdAsync(long id);
    }
}
