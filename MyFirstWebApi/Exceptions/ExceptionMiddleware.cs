using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyFirstWebApi.Exceptions
{
    public class ExceptionMiddleware
    {
        //private const object DomainException;
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = ex switch
            {
                HttpRequestException httpRequestException => httpRequestException.StatusCode is null ? 500 : (int)httpRequestException.StatusCode,
                ApiExceptionBase => 515,
                _ => 500
            };

            await context.Response.WriteAsync(MapException(ex).ToString());
        }

        private ErrorDetail MapException(Exception ex)
        {
            if (ex is ApiExceptionBase domainException)
            {
                return new ErrorDetail(domainException.Message, domainException.Code);
            }
            return new ErrorDetail(ex.Message, "error");
        }
    }
}
