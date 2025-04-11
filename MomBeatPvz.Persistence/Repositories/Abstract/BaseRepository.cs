using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Application.Operations.UnitOfWork;
using MomBeatPvz.Core.Exceptions;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.Model.Abstract;
using MomBeatPvz.Core.ModelCreate.Abstract;
using MomBeatPvz.Core.ModelUpdate.Abstract;
using MomBeatPvz.Core.Store.Abstract;
using MomBeatPvz.Persistence.Entities;
using MomBeatPvz.Persistence.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Repositories.Abstract
{
    public abstract class BaseRepository<M, C, U, E, I> : IStore<M, C, U, I>
        where M : IModel<I>
        where C : ICreateModel<M>
        where U : IUpdateModel<M, I>
        where E : class, IEntity<M, I>
    {
        protected readonly ApplicationContext _db;

        protected readonly IMapper _mapper;

        protected readonly IUnitOfWork _unitOfWork;

        public BaseRepository(ApplicationContext db, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _db = db;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task Create(C model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<E>(model);

            _db.GetDbSet<E>().Attach(entity);

            var entries = _db.ChangeTracker.Entries();

            await _db.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Delete(I id, CancellationToken cancellationToken)
        {
            await _db.GetDbSet<E>()
                .Where(x => x.Id!.Equals(id))
                .ExecuteDeleteAsync(cancellationToken);
        }

        public virtual async Task<bool> Exist(I id, CancellationToken cancellationToken)
        {
            return await _db.GetDbSet<E>()
                .Where(x => x.Id!.Equals(id))
                .AnyAsync(cancellationToken);
        }

        public virtual async Task<IReadOnlyCollection<M>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _db.GetDbSet<E>().ToListAsync(cancellationToken);

            return _mapper.Map<IReadOnlyCollection<M>>(entities);
        }

        public virtual async Task<M> GetById(I id, CancellationToken cancellationToken)
        {
            var existed = await _db.GetDbSet<E>()
                .FirstOrDefaultAsync(x => x.Id!.Equals(id), cancellationToken);

            return _mapper.Map<M>(existed);
        }

        public virtual async Task Update(U model, CancellationToken cancellationToken)
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var existed = await _db.GetDbSet<E>()
                .FirstOrDefaultAsync(x => x.Id!.Equals(model.Id), cancellationToken)
                ?? throw new NotFoundException();

                _mapper.Map(model, existed);

                var entries = _db.ChangeTracker.Entries();

                await _db.SaveChangesAsync(cancellationToken);
            }, cancellationToken);  
        }
    }
}
