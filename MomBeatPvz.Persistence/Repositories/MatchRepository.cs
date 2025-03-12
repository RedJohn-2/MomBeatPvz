using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Application.Operations.UnitOfWork;
using MomBeatPvz.Core.Exceptions;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Persistence.Entities;
using MomBeatPvz.Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Repositories
{
    public class MatchRepository :
        BaseRepository<Match, MatchCreateModel, MatchUpdateModel, MatchEntity, long>,
        IMatchStore
    {
        public MatchRepository(ApplicationContext db, IMapper mapper, IUnitOfWork unitOfWork) : base(db, mapper, unitOfWork)
        {
        }

        public async override Task<Match> GetById(long id)
        {
            var existed = await _db.Matches
                .Include(m => m.Results)
                .FirstOrDefaultAsync(x => x.Id!.Equals(id));

            return _mapper.Map<Match>(existed);
        }

        public async override Task<IReadOnlyList<Match>> GetAll()
        {
            var entities = await _db.Matches.ToListAsync();

            return _mapper.Map<IReadOnlyList<Match>>(entities);
        }

        public async override Task Update(MatchUpdateModel model)
        {
            var existedMatch = await _db.Matches
                .FirstOrDefaultAsync(s => s.Id == model.Id)
                ?? throw new NotFoundException();

            await _db.MatchResults
                .Where(m => m.Match == existedMatch)
                .ExecuteDeleteAsync();

            _mapper.Map(model, existedMatch);

            await _db.SaveChangesAsync();
        }
    }
}
