﻿using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.Store.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Store
{
    public interface ITierListStore : IStore<TierList, TierListCreateModel, TierListUpdateModel, long>
    {
        Task<IReadOnlyList<TierList>> GetByName(string name);

    }
}
