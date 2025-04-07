namespace Debugify.API.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Pre-processing logic before passing to the next middleware
            await context.Response.WriteAsync("Before Middleware Logic\n");
            var userAgent = context.Request.Headers["User-Agent"];
            context.Items["RequestStartTime"] = DateTime.UtcNow;

            // Pass control to the next middleware in the pipeline
            await _next(context);

            // Post-processing logic after the next middleware has executed
            await context.Response.WriteAsync("After Middleware Logic\n");
        }
    }
}
