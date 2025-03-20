using MomBeatPvz.Api.Contracts;
using MomBeatPvz.Core.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;

namespace MomBeatPvz.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Core.Exceptions.AuthenticationException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            HttpStatusCode statusCode,
            string message)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)statusCode;

            var result = new
            {
                StatusCode = (int)statusCode,
                Message= message
            };

            await response.WriteAsJsonAsync(result);
        }
    }
}
