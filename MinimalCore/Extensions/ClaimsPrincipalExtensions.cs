using System.Security.Claims;

namespace PortfolioApp.MinimalCore.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims
            (this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            return claimsPrincipal?.FindAll(claimType)
                        .Select(x => x.Value)
                        .ToList() ?? new List<string>();
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role) ?? new List<string>();
        }
        public static string GetClaim(this ClaimsPrincipal principal, string claimType)
        {
            return principal?.FindFirst(claimType)?.Value ?? string.Empty;
        }
        public static bool HasClaim(this ClaimsPrincipal principal, string claimType, string value)
        {
            return principal?.Claims(claimType).Contains(value) ?? false;
        }
        public static bool HasRole(this ClaimsPrincipal principal, string role)
        {
            return principal?.ClaimRoles().Contains(role) ?? false;
        }
        public static bool TryGetClaim(this ClaimsPrincipal principal, string claimType, out string? value)
        {
            value = principal?.FindFirst(claimType)?.Value;
            return !string.IsNullOrWhiteSpace(value);
        }

        public static T GetUserId<T>(this ClaimsPrincipal principal)
        {

            var userId = principal?.GetClaim(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                throw new Exception($"The {ClaimTypes.NameIdentifier} couldn't be found");

            if (typeof(T) == typeof(Guid))
                return (T)(object)Guid.Parse(userId);

            return (T)Convert.ChangeType(userId, typeof(T));
        }

        public static string GetEmail(this ClaimsPrincipal principal)
        {
            var email = principal?.GetClaim(ClaimTypes.Email);
            if (string.IsNullOrEmpty(email))
                throw new Exception($"The {ClaimTypes.Email} couldn't be found");
            return email;
        }

        public static List<string> GetRoles(this ClaimsPrincipal principal)
        {
            return principal?.ClaimRoles() ?? new List<string>();
        }
    }
}
