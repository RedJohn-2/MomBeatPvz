using Microsoft.Extensions.Caching.Distributed;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.Model.Abstract;
using MomBeatPvz.Core.ModelCreate.Abstract;
using MomBeatPvz.Core.ModelUpdate.Abstract;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Core.Store.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services.Abstract
{
    public class BaseService<M, C, U, I, S> : IService<M, C, U, I>
        where M : IModel<I>
        where C : ICreateModel<M>
        where U : IUpdateModel<M, I>
        where S : IStore<M, C, U, I>
    {
        protected readonly S _store;
        protected readonly IDistributedCache _distributedCache;

        public BaseService(S store, IDistributedCache distributedCache)
        {
            _store = store;
            _distributedCache = distributedCache;
        }

        public virtual async Task CreateAsync(C model)
        {
            await _store.Create(model);
        }

        public virtual async Task<M?> GetByIdAsync(I id)
        {
            var cacheKey = $"{nameof(M).ToLower()}-{id}";

            var stringData = await _distributedCache.GetStringAsync(cacheKey);

            if (string.IsNullOrEmpty(stringData))
            {
                var model = await _store.GetById(id);

                if (model is not null)
                {
                    await _distributedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(model));
                }

                return model;
            }

            return JsonSerializer.Deserialize<M>(stringData!);
        }

        public virtual async Task UpdateAsync(U model)
        {
            await _store.Update(model);
        }
    }
}
