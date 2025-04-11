using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Infrastructure.Cache
{
    public class RedisOptions
    {
        public int ExpirationTimeSeconds { get; set; }
    }
}
