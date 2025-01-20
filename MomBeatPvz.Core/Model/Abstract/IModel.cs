using MomBeatPvz.Core.ModelCreate.Abstract;
using MomBeatPvz.Core.ModelUpdate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model.Abstract
{
    public interface IModel<I> : IModel
    {
        public I Id { get; set; }
    }

    public interface IModel
    { }
}
