using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Core.Exceptions;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Persistence.Entities;
using MomBeatPvz.Persistence.Repositories.Abstract;

namespace MomBeatPvz.Persistence.Repositories
{
    public class UserRepository :
        BaseRepository<User, UserCreateModel, UserUpdateModel, UserEntity, long>,
        IUserStore
    {
        public UserRepository(ApplicationContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override Task Update(UserUpdateModel model)
        {
            throw new NotImplementedException();
        }

        public override async Task Create(UserCreateModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);

            await _db.AddAsync(entity);

            await _db.SaveChangesAsync();
        }
    }
}
