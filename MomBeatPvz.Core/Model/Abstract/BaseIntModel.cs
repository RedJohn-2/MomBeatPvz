using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model.Abstract
{
    public abstract class BaseIntModel: IModel<int>
    {
        public int Id { get; set; }
    }
}
