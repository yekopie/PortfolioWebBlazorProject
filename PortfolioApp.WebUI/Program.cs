using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Repository;
using PortfolioApp.MinimalCore.FileStorage;
using PortfolioApp.WebUI.Components;
using PortfolioApp.WebUI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAntiforgery(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
});
// DbContext
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

//Authentication & Authorization
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(
    sp => sp.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();

// File storage
builder.Services.AddScoped<IFileStorageService>(sp =>
    new FileStorageService(Path.Combine(builder.Environment.ContentRootPath, "wwwroot")));

// Blazor Server
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.DetailedErrors = true;
        }
    });

builder.Services.AddAuthorization();

var app = builder.Build();
// global exception middleware
app.UseExceptionMiddleware();
// Ensure database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthorization();

// Blazor endpoint
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
