namespace PortfolioApp.WebUI.Extensions
{
    public static class HttpContextAccessorExtensions
    {
        public static HttpContext EnsureHttpContext(this IHttpContextAccessor accessor)
        {
            return accessor.HttpContext ??
                   throw new InvalidOperationException("HTTP context is null.");
        }
    }
}
