using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services.Interfaces
{
    public interface IChampionshipService 
        : IService<Championship, ChampionshipCreateModel, ChampionshipUpdateModel, long>
    {
    }
}
