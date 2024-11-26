
using BabyTravel.Api.Exceptions;
using BabyTravel.Api.Models;
using BabyTravel.Api.Models.Shared;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace BabyTravel.Api.Middleware
{
    public class ErrorResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode =
                    ex is BaseException baseException
                    ? (int)baseException.StatusCode
                    : (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsJsonAsync(new ErrorResponse(ex.Message));
            }
        }
    }
}
