using PortfolioApp.WebUI.Dtos;
namespace PortfolioApp.WebUI.Services
{
    public interface IAuthService
    {
        public Task<bool> Login(LoginDto dto);
        public Task<bool> Logout();
    }
}