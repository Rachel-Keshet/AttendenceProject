
namespace Web.Net.API.Middleware
{
    public class ShabbatMiddleware
    {
        private readonly RequestDelegate _next;

        public ShabbatMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Service is unavailable on Shabbat");
                return;
            }

            await _next(context);
        }
    }
}
