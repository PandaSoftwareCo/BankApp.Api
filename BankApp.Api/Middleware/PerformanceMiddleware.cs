using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace BankApp.Api.Middleware
{
    public class PerformanceMiddleware
    {
        private const string RESPONSE_HEADER_RESPONSE_TIME = "X-Response-Time-ms";
        private readonly RequestDelegate _next;
        private readonly ILogger<PerformanceMiddleware> _logger;

        public PerformanceMiddleware(RequestDelegate next, ILogger<PerformanceMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();

            context.Response.OnStarting(state =>
            {
                watch.Stop();
                string value = $"{watch.ElapsedMilliseconds} ms";
                context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = value;
                _logger.LogInformation($"{context.Request.Method} {context.Request.Path.Value} - {watch.ElapsedMilliseconds} ms");
                return Task.CompletedTask;
            }, context);
            await _next(context);
        }
    }

    public static class PerformanceMiddlewareExtensions
    {
        public static IApplicationBuilder UsePerformanceMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<PerformanceMiddleware>();
        }
    }
}
