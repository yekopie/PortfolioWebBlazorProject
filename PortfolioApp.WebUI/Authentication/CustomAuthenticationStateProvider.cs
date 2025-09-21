using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using PortfolioApp.Data.Entities;
using PortfolioApp.Data.Repository;
using PortfolioApp.MinimalCore.Security;
using PortfolioApp.WebUI;
using PortfolioApp.WebUI.Dtos;
using System.Security.Claims;

public class CustomAuthenticationStateProvider(
    IGenericRepository<User> userRepository,
    ProtectedSessionStorage sessionStorage
    ) : AuthenticationStateProvider
{
    private readonly IGenericRepository<User> _userRepository = userRepository;
    private readonly ProtectedSessionStorage _sessionStorage = sessionStorage;

    private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var result = await _sessionStorage.GetAsync<string>("username");
            if (result.Success && !string.IsNullOrEmpty(result.Value))
            {
                var user = await _userRepository.FirstOrDefaultAsync(
                    u => u.Username == result.Value,
                    u => u.Profile
                );

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Profile.Name),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    _currentUser = new ClaimsPrincipal(new ClaimsIdentity(claims, BlazorConstants.AuthCustom));
                }
            }
        }
        catch
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        }

        return new AuthenticationState(_currentUser);
    }

    public async Task Login(LoginDto dto)
    {
        var user = await _userRepository.FirstOrDefaultAsync(
            u => u.Username == dto.Username,
            u => u.Profile
        );

        if (user == null || !HashingHelper.VerifyPassword(dto.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Profile.Name),
            new Claim(ClaimTypes.Role, user.Role)
        };

        _currentUser = new ClaimsPrincipal(new ClaimsIdentity(claims, BlazorConstants.AuthCustom));

        // Circuit reset sonrası da state’i sakla
        await _sessionStorage.SetAsync("username", user.Username);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }

    public async Task Logout()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        await _sessionStorage.DeleteAsync("username");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }
}