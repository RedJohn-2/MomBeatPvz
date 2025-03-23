using Microsoft.Extensions.Caching.Distributed;
using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Application.Services.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services
{
    public class TierListService : 
        BaseService<TierList, TierListCreateModel, TierListUpdateModel, long, ITierListStore>,
        ITierListService
    {
        public TierListService(ITierListStore tierListStore, IDistributedCache distributedCache) 
            : base(tierListStore, distributedCache)
        {
        }

        public async Task<IReadOnlyCollection<TierList>> GetAllAsync()
        {
            return await _store.GetAll();
        }
    }
}
