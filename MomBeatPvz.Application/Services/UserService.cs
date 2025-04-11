using Microsoft.Extensions.Caching.Distributed;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Operations.UnitOfWork;
using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Application.Services.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.Store;
using System.Security.Authentication;
using System.Security.Claims;

namespace MomBeatPvz.Application.Services
{
    public class UserService : 
        BaseService<User, UserCreateModel, UserUpdateModel, long, IUserStore>,
        IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IJwtProvider _jwtProvider;

        private readonly IHashProvider _hashProvider;

        public UserService(
            IUserStore userStore, 
            IUnitOfWork unitOfWork, 
            IJwtProvider jwtProvider, 
            IHashProvider hashProvider,
            ICacheProvider cache)
            : base(userStore, cache)
        {
            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
            _hashProvider = hashProvider;
        }

        protected override string ModelName => nameof(User);

        public async Task<string> AuthAsync(long id, string username, DateTime expired, string hash, CancellationToken cancellationToken)
        {
            return await _unitOfWork.InTransaction(async () =>
            {
                var authValid = _hashProvider.IsValid(id, username, expired, hash);

                if (!authValid)
                {
                    throw new AuthenticationException();
                }

                var existedUser = await _store.GetById(id, cancellationToken);

                if (existedUser is null) 
                {
                    existedUser = new User
                    {
                        Id = id,
                        Name = username
                    };

                    await _store.Create(new UserCreateModel { Id = existedUser.Id, Name = existedUser.Name}, cancellationToken);
                }

                return _jwtProvider.GenerateAccessToken(existedUser);
                                    
            }, cancellationToken);
        }

        public override Task CreateAsync(UserCreateModel model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Невозможная операция!!!");
        }

        public override Task UpdateAsync(UserUpdateModel model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Невозможная операция!!!");
        }
    }
}
