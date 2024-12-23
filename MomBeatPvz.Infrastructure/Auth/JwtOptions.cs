using System.Net;

namespace MomBeatPvz.Infrastructure.Auth
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;

        public int ExpiresAccessTokenSeconds { get; set; }
    }
}
