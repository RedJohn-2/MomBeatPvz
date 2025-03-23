using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services.Interfaces
{
    public interface IMatchService :
        IService<Match, MatchCreateModel, MatchUpdateModel, long>
    {
        void CheckDuplicates(List<Match> matches);
    }
}
