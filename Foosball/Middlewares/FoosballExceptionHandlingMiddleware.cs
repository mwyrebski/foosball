using System;
using System.Threading.Tasks;
using Foosball.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Foosball.Middlewares
{
    public class FoosballExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public FoosballExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (FoosballException ex)
            {
                await HandleFoosballExceptionAsync(context, ex);
            }
        }

        private async Task HandleFoosballExceptionAsync(HttpContext context, FoosballException exception)
        {
            var errorMessage = exception.Message;

            if (exception is FoosballInvalidDataException)
            {
                await SetErrorResponseAsync(context, StatusCodes.Status400BadRequest, errorMessage);
                return;
            }

            await SetErrorResponseAsync(context, StatusCodes.Status500InternalServerError, errorMessage);
        }


        private async Task SetErrorResponseAsync(HttpContext context, int statusCode, string errorMessage)
        {
            if (context.Response.HasStarted)
            {
                // The response has already been started and cannot be modified.
                return;
            }

            var body = JsonConvert.SerializeObject(new {error = errorMessage});
            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(body);
        }
    }
}