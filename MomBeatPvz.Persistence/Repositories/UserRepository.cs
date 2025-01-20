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
    }
}
