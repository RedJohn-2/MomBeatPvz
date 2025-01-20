using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model.Abstract
{
    public abstract class BaseGuidModel : IModel<Guid>
    {
        public Guid Id { get; set; }
    }
}
