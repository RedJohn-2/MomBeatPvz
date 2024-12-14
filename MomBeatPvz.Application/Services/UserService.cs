using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Operations.UnitOfWork;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.Store;
using System.Security.Claims;

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

        public async Task AuthAsync(User user, IEnumerable<Claim> claims)
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var existedUser = await _userStore.GetById(user.Id);

                if (existedUser is null) 
                {
                    await _userStore.Create(user);
                }
                else
                {
                    claims.Append(new Claim("Admin", "Role"));
                }
            });
        }

        public async Task<User> GetByIdAsync(long id)
        {
            return await _userStore.GetById(id);
        }

        public Task<bool> IsAdminAsync(long id)
        {
            return _userStore.IsAdmin(id);
        }
    }
}
