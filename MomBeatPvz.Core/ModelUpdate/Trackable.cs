using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelUpdate
{
    /// <summary>
    /// Вспомогательный класс - обертка, навешивается на UpdateModel на поля, которые могут быть Null, чтобы различать null - значение поле и null - отсутствие значения.
    /// Также навешивается на поля значимых типов, для них выступает в роли отсутствия значения.
    /// Если Trackable поле Null, то поле не отслеживается, его значение изменено не будет, если же не null, то значение изменение будет на Value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Trackable<T>
    {
        public T? Value { get; set; } = default;

    }
}
