using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Interfaces
{
    public interface ITeamService
    {
        Task CreateAsync(TeamCreateModel model);

        Task UpdateAsync(TeamUpdateModel model);

        Task<Team> GetByIdAsync(long id);

        void CheckDuplicates(List<Team> teams);
    }
}
