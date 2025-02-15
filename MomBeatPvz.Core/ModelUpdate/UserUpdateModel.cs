using MomBeatPvz.Core.ModelUpdate.Abstract;

namespace MomBeatPvz.Core.Model
{
    /// <summary>
    /// Класс-заглушка. Для юзера не предусмотрен Update, нужно для реализации интерфейса IStore. Возможно в будущем Update понадобится.
    /// </summary>
    public class UserUpdateModel : IUpdateModel<User, long>
    {
        public long Id { get; set; }
    }
}
