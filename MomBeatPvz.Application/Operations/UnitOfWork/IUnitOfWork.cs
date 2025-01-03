using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Application.Operations.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task InTransaction(Func<Task> action, Exception? ex = null);

        Task<T> InTransaction<T, E>(Func<Task<T>> action, E? ex = null) where E : Exception;
    }
}
