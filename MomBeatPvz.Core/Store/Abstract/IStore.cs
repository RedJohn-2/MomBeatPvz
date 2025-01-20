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
        Task Create(C model);

        Task Update(U model);

        Task Delete(I id);

        Task<M> GetById(I id);

        Task<IReadOnlyList<M>> GetAll();

        Task<bool> Exist(I id);
    }
}
