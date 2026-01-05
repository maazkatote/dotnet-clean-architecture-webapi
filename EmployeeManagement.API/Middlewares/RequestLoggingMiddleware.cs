using System.Diagnostics;

namespace EmployeeManagement.API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private const string RequestIdHeader = "X-Request-Id";
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestId = context.TraceIdentifier;

            context.Response.Headers[RequestIdHeader] = requestId;

            using (_logger.BeginScope("RequestId:{RequestId}", requestId))
            {
                _logger.LogInformation(
                    "Incoming {Method} {Path}",
                    context.Request.Method,
                    context.Request.Path);

                await _next(context);

                _logger.LogInformation(
                    "Outgoing {StatusCode}",
                    context.Response.StatusCode);
            }
        }
    }
}
