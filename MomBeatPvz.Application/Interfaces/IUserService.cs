using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Interfaces
{
    public interface IUserService
    {
        Task AuthAsync(User user);

        Task<User> GetByIdAsync(long id);
    }
}
