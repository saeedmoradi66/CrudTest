using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;


namespace Project1.Domain.Exceptions
{
    public sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);

            var response = new Response<IReadOnlyCollection<ValidationError>>(GetErrors(exception), false);


            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = statusCode;
            if(response.Data!=null)
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            else
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(exception.Message));
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {

                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                ApplicationException applicationException => applicationException.Message,
                _ => "Server Error"
            };

        private static IReadOnlyCollection<ValidationError> GetErrors(Exception exception)
        {
            IReadOnlyCollection<ValidationError> errors = null;

            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors;
            }
            
            return errors;
        }
    }
}
