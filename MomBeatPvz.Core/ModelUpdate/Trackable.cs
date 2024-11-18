using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelUpdate
{
    public class Trackable<T>
    {
        public T? Field { get; private set; }
        public bool IsTracked { get; private set; }

        public static Trackable<T> TrackField(T field)
        {
            return new Trackable<T>
            {
                Field = field,
                IsTracked = true
            };
        }
    }
}
