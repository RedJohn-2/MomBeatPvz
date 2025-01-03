using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Interfaces
{
    public interface IHashProvider
    {
        bool IsValid(long id, string username, DateTime expired, string hash);
    }
}
