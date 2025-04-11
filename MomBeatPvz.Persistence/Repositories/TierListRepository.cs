using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Application.Operations.UnitOfWork;
using MomBeatPvz.Core.Exceptions;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Persistence.Entities;
using MomBeatPvz.Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MomBeatPvz.Persistence.Repositories
{
    public class TierListRepository : 
        BaseRepository<TierList, TierListCreateModel, TierListUpdateModel, TierListEntity, long>,
        ITierListStore
    {
        public TierListRepository(ApplicationContext db, IMapper mapper, IUnitOfWork unitOfWork) : base(db, mapper, unitOfWork)
        {
        }

        public override async Task<IReadOnlyCollection<TierList>> GetAll(CancellationToken cancellationToken)
        {
            var existedTierLists = await _db.TierLists
                .Include(x => x.Creator)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IReadOnlyCollection<TierList>>(existedTierLists);
        }

        public override async Task<TierList> GetById(long id, CancellationToken cancellationToken)
        {
            var existedTierList = await _db.TierLists
                .Include(t => t.Creator)
                .Include(t => t.Championship)
                .ThenInclude(c => c.Heroes)
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

            return _mapper.Map<TierList>(existedTierList);
        }

        public async Task<IReadOnlyCollection<TierList>> GetByName(string name, CancellationToken cancellationToken)
        {
            var existedTierLists = await _db.TierLists
                .Include(t => t.Creator)
                .Where(t => t.Name == name)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IReadOnlyCollection<TierList>>(existedTierLists);
        }

        public override async Task Update(TierListUpdateModel model, CancellationToken cancellationToken)
        {
            await _unitOfWork.InTransaction(async () =>
            {
                var existed = await _db.TierLists
                .Include(x => x.Creator)
                .FirstOrDefaultAsync(x => x.Id!.Equals(model.Id), cancellationToken)
                ?? throw new NotFoundException();

                if (existed.Creator.Id != model.AuthorId)
                {
                    throw new ForbiddenException("Нельзяа редактировать чужой тирлист!");
                }

                _mapper.Map(model, existed);

                var entries = _db.ChangeTracker.Entries();

                await _db.SaveChangesAsync(cancellationToken);
            }, cancellationToken);
        }
    }
}
