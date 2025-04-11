using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services.Interfaces
{
    public interface IUserService : IService<User, UserCreateModel, UserUpdateModel, long>
    {
        Task<string> AuthAsync(long id, string username, DateTime expired, string hash, CancellationToken cancellationToken);

    }
}
