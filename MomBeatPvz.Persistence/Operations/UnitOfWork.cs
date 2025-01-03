using Microsoft.EntityFrameworkCore.Storage;
using MomBeatPvz.Application.Operations.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Operations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _db;

        public UnitOfWork(ApplicationContext db)
        { 
            _db = db; 
        }

        public async Task InTransaction(Func<Task> action, Exception? ex = null)
        {
            await using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                await action();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();

                if (ex is not null)
                {
                    throw ex;
                }
            }
        }

        public async Task<T> InTransaction<T, E>(Func<Task<T>> action, E? ex = null) where E : Exception
        {
            await using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var result = await action();

                await transaction.CommitAsync();

                return result;
            }
            catch
            {
                await transaction.RollbackAsync();

                if (ex is not null)
                {
                    throw ex;  
                }

                throw new Exception();
            }
        }
    }
}
