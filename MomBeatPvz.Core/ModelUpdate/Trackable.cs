using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelUpdate
{
    public class Trackable<T>
    {
        public T? Value { get; set; }

        public bool IsTracked { get; set; }

    }
}
