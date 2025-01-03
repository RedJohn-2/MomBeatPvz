using MomBeatPvz.Application.Operations.UnitOfWork;

namespace MomBeatPvz.Persistence.Operations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _db;

        public UnitOfWork(ApplicationContext db)
        { 
            _db = db; 
        }

        public async Task InTransaction(Func<Task> action)
        {
            await using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                await action();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                throw;
            }
        }     

        public async Task<T> InTransaction<T>(Func<Task<T>> action)
        {
            await using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var result = await action();

                await transaction.CommitAsync();

                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                throw;
            }
        }
    }
}
