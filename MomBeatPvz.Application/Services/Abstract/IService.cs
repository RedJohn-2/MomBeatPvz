﻿using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.Model.Abstract;
using MomBeatPvz.Core.ModelCreate.Abstract;
using MomBeatPvz.Core.ModelUpdate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Services.Abstract
{
    public interface IService<M, C, U, I>
        where M : IModel<I>
        where C : ICreateModel<M>
        where U : IUpdateModel<M, I>
    {
        Task CreateAsync(C model, CancellationToken cancellationToken);

        Task UpdateAsync(U model, CancellationToken cancellationToken);

        Task<M?> GetByIdAsync(I id, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<M>> GetAllAsync(CancellationToken cancellationToken);
    }
}
