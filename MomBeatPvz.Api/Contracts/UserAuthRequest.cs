namespace MomBeatPvz.Api.Contracts
{
    public class UserAuthRequest
    {
        public long Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public DateTime Expired { get; set; }

        public string Hash { get; set; } = string.Empty;
    }
}
