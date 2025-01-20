using Microsoft.EntityFrameworkCore.Metadata;
using MomBeatPvz.Core.Model.Abstract;


namespace MomBeatPvz.Persistence.Entities.Abstract
{
    public interface IEntity<M, I> : IEntity where M : IModel<I>
    {
        public I Id { get; set; }
    }

    public interface IEntity
    {
    }
}
