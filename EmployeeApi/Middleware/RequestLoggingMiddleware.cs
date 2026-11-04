namespace EmployeeApi.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context) {
            var request = context.Request.Path;
            var requestTime = DateTime.Now;

            Console.WriteLine($"Request: {request}, Time: {requestTime}");
            await _next(context);
        }
    }
}
