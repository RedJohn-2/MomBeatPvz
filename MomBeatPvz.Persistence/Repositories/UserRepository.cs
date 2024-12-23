using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Repositories
{
    public class UserRepository : IUserStore
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationContext db, IMapper mapper)
        {  
            _db = db;
            _mapper = mapper;
        }

        public async Task Create(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);

            await _db.AddAsync(user);

            await _db.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<User>> GetAll()
        {
            var userEntities = await _db.Users.ToListAsync();

            return _mapper.Map<List<User>>(userEntities);
        }

        public async Task<User> GetById(long id)
        {
            var userEntity = await _db.Users
                .FirstOrDefaultAsync(u => u.Id == id)
                ?? throw new Exception();

            return _mapper.Map<User>(userEntity);
        }

        public async Task<User> GetBySecret(Guid secret)
        {
            var userEntity = await _db.Users
                .FirstOrDefaultAsync(u => u.Secret == secret)
                ?? throw new Exception();

            return _mapper.Map<User>(userEntity);
        }

        public async Task Update(UserUpdateModel model)
        {
            var existedUser = await _db.Users
                .FirstOrDefaultAsync(u => u.Id == model.Id)
                ?? throw new Exception();

            _mapper.Map(model, existedUser);

            await _db.SaveChangesAsync();
        }
    }
}
