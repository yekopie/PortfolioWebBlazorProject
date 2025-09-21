using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using PortfolioApp.Data.Entities;
using PortfolioApp.Data.Repository;
using PortfolioApp.MinimalCore.Security;
using PortfolioApp.WebUI.Dtos;
using PortfolioApp.WebUI.Extensions;
using System.Security.Claims;

namespace PortfolioApp.WebUI.Services
{
    public class CookieAuthService(IGenericRepository<User> userRepository, IHttpContextAccessor httpContextAccessor) : IAuthService
    {
        public async Task<bool> Login(LoginDto dto)
        {
            try
            {
                var user = await userRepository.FirstOrDefaultAsync(
                    predicate: u => u.Username == dto.Username,
                    includes: u => u.Profile
                    );

                // Kullanıcı bulunamazsa veya şifre doğrulanamazsa false döner
                if (user == null || HashingHelper.VerifyPassword(dto.Password, user.PasswordHash))
                    return false;


                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Profile.Name),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30)
                };
                var context = httpContextAccessor.EnsureHttpContext();
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during the login", ex);
            }

        }

        public async Task<bool> Logout()
        {
            var context = httpContextAccessor.EnsureHttpContext();
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return true;
        }

    }

}