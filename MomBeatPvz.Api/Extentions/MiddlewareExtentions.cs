using MomBeatPvz.Api.Middlewares;

namespace MomBeatPvz.Api.Extentions
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
