using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Interfaces
{
    public interface IMatchService
    {
        Task CreateAsync(MatchCreateModel model);

        Task UpdateAsync(MatchUpdateModel model);

        Task<Match> GetByIdAsync(long id);
    }
}
