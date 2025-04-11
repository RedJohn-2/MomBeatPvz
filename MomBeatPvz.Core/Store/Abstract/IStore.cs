using MomBeatPvz.Core.Model.Abstract;
using MomBeatPvz.Core.ModelCreate.Abstract;
using MomBeatPvz.Core.ModelUpdate.Abstract;

namespace MomBeatPvz.Core.Store.Abstract
{
    public interface IStore<M, C, U, I> 
        where M : IModel<I>
        where C : ICreateModel<M>
        where U : IUpdateModel<M, I>
    {
        Task Create(C model, CancellationToken cancellationToken);

        Task Update(U model, CancellationToken cancellationToken);

        Task Delete(I id, CancellationToken cancellationToken);

        Task<M> GetById(I id, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<M>> GetAll(CancellationToken cancellationToken);

        Task<bool> Exist(I id, CancellationToken cancellationToken);
    }
}
