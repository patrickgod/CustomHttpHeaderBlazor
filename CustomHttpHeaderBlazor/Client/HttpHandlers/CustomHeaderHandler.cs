namespace CustomHttpHeaderBlazor.Client.HttpHandlers
{
    public class CustomHeaderHandler : DelegatingHandler
    {
        public CustomHeaderHandler() : base(new HttpClientHandler()) { }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Custom-Header", "My Custom Header Value");
            return base.SendAsync(request, cancellationToken);
        }
    }
}
