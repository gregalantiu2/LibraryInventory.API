using System.Net;
using System.Text.Json;

namespace LibraryInventory.API.Middleware
{
    public class ExceptionHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleWare> _logger;

        public ExceptionHandlingMiddleWare(RequestDelegate next, ILogger<ExceptionHandlingMiddleWare> logger)
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"Message: {exception.Message} | InnerException: {exception.InnerException?.Message}"
            }.ToString();

            _logger.LogError(errorDetails);

            return context.Response.WriteAsync(errorDetails);
        }
    }
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
