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

        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserStore userStore, IUnitOfWork unitOfWork, IJwtProvider jwtProvider)
        {
            _userStore = userStore;
            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> AuthAsync(long telegramId, string name, Guid secret)
        {
            string token = string.Empty;

            await _unitOfWork.InTransaction(async () =>
            {
                var existedUser = await _userStore.GetBySecret(secret);

                if (existedUser is null) 
                {
                    throw new Exception();
                }

                if (existedUser.Created == DateTime.MinValue)
                {
                    await _userStore.Update(
                        new UserUpdateModel()
                        {
                            Id = existedUser.Id,
                            Name = name,
                            TelegramId = telegramId,
                            Created = DateTime.UtcNow
                        });
                }

                token = _jwtProvider.GenerateAccessToken(existedUser);
                                    
            });

            return token;
        }

        public async Task<string> CreateAsync()
        {
            var newUser = new User();

            await _userStore.Create(newUser);

            return newUser.Secret.ToString();
        }

        public async Task<User> GetByIdAsync(long id)
        {
            return await _userStore.GetById(id);
        }

    }
}
