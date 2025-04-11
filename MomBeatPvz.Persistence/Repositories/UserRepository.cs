using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Application.Operations.UnitOfWork;
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
        public UserRepository(ApplicationContext db, IMapper mapper, IUnitOfWork unitOfWork) : base(db, mapper, unitOfWork)
        {
        }

        public override Task Update(UserUpdateModel model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task Create(UserCreateModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UserEntity>(model);

            await _db.AddAsync(entity, cancellationToken);

            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
