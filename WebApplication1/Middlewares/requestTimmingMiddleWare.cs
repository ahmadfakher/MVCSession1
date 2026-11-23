using System.Diagnostics;

namespace WebApplication1.Middlewares
{
    public class requestTimmingMiddleWare
    {
        private RequestDelegate _next;

        public requestTimmingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();
            Console.WriteLine($"{context.Request.Path}: {watch.ElapsedMilliseconds}ms");
        }
    }
}
