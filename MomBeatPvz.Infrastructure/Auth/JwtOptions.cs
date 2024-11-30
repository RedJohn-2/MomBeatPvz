using System.Net;

namespace MomBeatPvz.Infrastructure.Auth
{
    public class JwtOptions
    {
        public string SecretKey = string.Empty;

        public string CookieAccessToken = string.Empty;
    }
}
