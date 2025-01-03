using Microsoft.Extensions.Options;
using MomBeatPvz.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Web;

namespace MomBeatPvz.Infrastructure.Auth
{
    public class HashProvider : IHashProvider
    {
        private readonly HashOptions _hashOptions;

        public HashProvider(IOptions<HashOptions> options)
        {
            _hashOptions = options.Value;
        }

        public bool IsValid(long id, string username, DateTime expired, string hash)
        {
            if (DateTime.UtcNow > expired)
            {
                return false;
            }

            var json = JsonSerializer.Serialize(new
            {
                Username = username,
                TelegramId = id,
                HashExpired = expired.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
            });

            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_hashOptions.SecretKey)))
            {
                var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(json));
                var hashString = Convert.ToBase64String(hashBytes);

                return hashString.Equals(hash);
            }
        }
    }
}
