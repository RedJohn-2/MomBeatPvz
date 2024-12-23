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
        Task AuthAsync(long telegramId, string name, Guid secret);

        Task<string> CreateAsync();

        Task<User> GetByIdAsync(long id);

    }
}
