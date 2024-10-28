using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvzDichTierList.Core.ModelUpdate
{
    public class Changed<T>
    {
        public bool IsChanged { get; private set; }

        public T? Field { get; private set; }

        public static Changed<T> CommitField(T field)
        {
            return new Changed<T> { IsChanged = true, Field = field };
        }
    }
}
