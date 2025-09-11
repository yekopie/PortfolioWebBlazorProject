namespace PortfolioApp.MinimalCore.Security;
public static class HashingHelper
{
    // Parola hashleme
    public static string HashPassword(string password)
    {
        // workfactor : default 11
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    // Parola doğrulama
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
