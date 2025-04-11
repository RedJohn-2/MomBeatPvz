using Microsoft.Extensions.Caching.Distributed;
using MomBeatPvz.Application.Interfaces;
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
    public abstract class BaseService<M, C, U, I, S> : IService<M, C, U, I>
        where M : IModel<I>
        where C : ICreateModel<M>
        where U : IUpdateModel<M, I>
        where S : IStore<M, C, U, I>
    {
        protected readonly S _store;
        protected readonly ICacheProvider _cache;
        protected abstract string ModelName { get; }

        public BaseService(S store, ICacheProvider cache)
        {
            _store = store;
            _cache = cache;
        }

        public virtual async Task CreateAsync(C model, CancellationToken cancellationToken)
        {
            await _store.Create(model, cancellationToken);
        }

        public virtual async Task<M?> GetByIdAsync(I id, CancellationToken cancellationToken)
        {
            var cacheKey = $"{ModelName.ToLower()}-{id}";

            var stringData = await _cache.Get(cacheKey, cancellationToken);

            if (string.IsNullOrEmpty(stringData))
            {
                var model = await _store.GetById(id, cancellationToken);

                if (model is not null)
                {
                    await _cache.Set(cacheKey, JsonSerializer.Serialize(model), cancellationToken);
                }

                return model;
            }

            return JsonSerializer.Deserialize<M>(stringData!);
        }

        public virtual async Task UpdateAsync(U model, CancellationToken cancellationToken)
        {
            await _store.Update(model, cancellationToken);
        }

        public virtual async Task<IReadOnlyCollection<M>> GetAllAsync(CancellationToken cancellationToken)
        {
            var cacheKey = $"{ModelName.ToLower()}-all";

            var stringData = await _cache.Get(cacheKey, cancellationToken);

            if (string.IsNullOrEmpty(stringData))
            {
                var list = await _store.GetAll(cancellationToken);

                if (list is not null)
                {
                    await _cache.Set(cacheKey, JsonSerializer.Serialize(list), cancellationToken);
                }

                return list ?? [];
            }

            return JsonSerializer.Deserialize<List<M>>(stringData)!;
        }

        public virtual async Task DeleteAsync(I id, CancellationToken cancellationToken)
        {
            await _store.Delete(id, cancellationToken);
        }
    }
}
