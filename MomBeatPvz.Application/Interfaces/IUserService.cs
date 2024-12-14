using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Interfaces
{
    public interface IUserService
    {
        Task AuthAsync(User user, IEnumerable<Claim> claims);

        Task<User> GetByIdAsync(long id);

        Task<bool> IsAdminAsync(long id);
    }
}
