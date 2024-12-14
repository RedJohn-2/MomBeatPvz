using System.Text.Json;

namespace MomBeatPvz.Api.Contracts
{
    public record ErrorResponse(int StatusCode, string Message)
    {
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
