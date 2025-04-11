using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Operations.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task InTransaction(Func<Task> action, CancellationToken cancellationToken);

        Task<T> InTransaction<T>(Func<Task<T>> action, CancellationToken cancellationToken);
    }
}
