namespace PortfolioApp.WebUI.Middlewares;

using System.Net;
using System.Text.Json;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            // Pipeline'da sıradaki middleware çalışsın
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            // Hata yakalanır
            _logger.LogError(ex, "Beklenmeyen bir hata oluştu");

            // Response hazırlanır
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var errorResponse = new
            {
                Message = "Bir hata oluştu. Lütfen tekrar deneyiniz.",
                Detail = ex.Message // production'da gizlenebilir
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
