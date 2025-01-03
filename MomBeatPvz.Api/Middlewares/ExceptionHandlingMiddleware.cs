using MomBeatPvz.Api.Contracts;
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
            catch (AuthenticationException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (ValidationException ex)
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

            ErrorResponse errorResponse = new((int)statusCode, message);

            string result = errorResponse.ToString();

            await response.WriteAsJsonAsync(result);
        }
    }
}
