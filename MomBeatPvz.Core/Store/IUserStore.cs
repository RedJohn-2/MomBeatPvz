using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Store
{
    public interface IUserStore
    {
        Task Create(User user);

        Task<User> GetById(long id);

        Task<User> GetBySecret(Guid secret);

        Task<IReadOnlyList<User>> GetAll();

        Task Update(UserUpdateModel model);
    }
}
