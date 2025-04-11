using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Infrastructure.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MomBeatPvz.Infrastructure.Cache
{
    public class RedisProvider : ICacheProvider
    {
        protected readonly IDistributedCache _distributedCache;
        private readonly RedisOptions _redisOptions;

        public RedisProvider(IDistributedCache distributedCache, IOptions<RedisOptions> options)
        {
            _distributedCache = distributedCache;
            _redisOptions = options.Value;
        }

        public async Task<string?> Get(string key, CancellationToken cancellationToken)
        {
            return await _distributedCache.GetStringAsync(key, cancellationToken);
        }

        public async Task Set(string key, string value, CancellationToken cancellationToken)
        {
            await _distributedCache.SetStringAsync(
                        key: key,
                        value: value,
                        options:
                            new DistributedCacheEntryOptions
                            {
                                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_redisOptions.ExpirationTimeSeconds)
                            },
                        token: cancellationToken);
        }
    }
}
