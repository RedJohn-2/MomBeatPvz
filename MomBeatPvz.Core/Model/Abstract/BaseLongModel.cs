using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model.Abstract
{
    public abstract class BaseLongModel : IModel<long>
    {
        public long Id { get; set; }
    }
}
