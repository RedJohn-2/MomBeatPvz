namespace MomBeatPvz.Core.Model
{
    public class UserUpdateModel
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime Created { get; set; }

        public long TelegramId { get; set; }
    }
}
