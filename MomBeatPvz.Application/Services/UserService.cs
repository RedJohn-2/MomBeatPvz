using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Operations.UnitOfWork;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserStore _userStore;

        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserStore userStore, IUnitOfWork unitOfWork)
        {
            _userStore = userStore;
            _unitOfWork = unitOfWork;
        }

        public async Task AuthAsync(User user)
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var existedUser = await _userStore.GetById(user.Id);

                if (existedUser == null) 
                {
                    await _userStore.Create(user);
                }
            });
        }

        public async Task<User> GetByIdAsync(long id)
        {
            return await _userStore.GetById(id);
        }
    }
}
