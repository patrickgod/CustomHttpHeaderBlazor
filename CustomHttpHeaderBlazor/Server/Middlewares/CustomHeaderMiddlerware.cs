using CustomHttpHeaderBlazor.Server.Services;

namespace CustomHttpHeaderBlazor.Server.Middlewares
{
    public class CustomHeaderMiddlerware
    {
        private readonly RequestDelegate _next;

        public CustomHeaderMiddlerware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, CustomHeaderService customHeaderService)
        {
            string? customHeader = context.Request.Headers["Custom-Header"].FirstOrDefault();

            if(!string.IsNullOrWhiteSpace(customHeader))
            {
                customHeaderService.CustomHeaderValue = customHeader;
                Console.WriteLine($"My custom header value is '{customHeaderService.CustomHeaderValue}'");
            }

            await _next(context);
        }
    }
}
