using System.Text.Json;

namespace MomBeatPvz.Api.Contracts
{
    public record ErrorResponse(int StatusCode, string Message)
    {
    }
}
