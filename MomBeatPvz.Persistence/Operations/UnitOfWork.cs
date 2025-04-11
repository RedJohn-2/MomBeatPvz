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

        public async Task InTransaction(Func<Task> action, CancellationToken cancellationToken)
        {
            await using var transaction = await _db.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                await action();

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);

                throw;
            }
        }     

        public async Task<T> InTransaction<T>(Func<Task<T>> action, CancellationToken cancellationToken)
        {
            await using var transaction = await _db.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var result = await action();

                await transaction.CommitAsync(cancellationToken);

                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);

                throw;
            }
        }
    }
}
