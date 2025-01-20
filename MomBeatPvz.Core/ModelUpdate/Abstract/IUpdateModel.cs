using MomBeatPvz.Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelUpdate.Abstract
{
    public interface IUpdateModel<M, I> where M : IModel<I>
    {
        public I Id { get; set; }
    }
}
