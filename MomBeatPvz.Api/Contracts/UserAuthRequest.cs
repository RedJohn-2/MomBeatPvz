namespace MomBeatPvz.Api.Contracts
{
    public class UserAuthRequest
    {
        public long TelegramId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Secret { get; set; } = string.Empty;
    }
}
