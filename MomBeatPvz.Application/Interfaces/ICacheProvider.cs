using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Interfaces
{
    public interface ICacheProvider
    {
        Task Set(string key, string value, CancellationToken cancellationToken);

        Task<string?> Get(string key, CancellationToken cancellationToken);
    }
}
