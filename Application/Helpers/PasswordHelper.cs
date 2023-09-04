namespace Application.Helpers;

internal sealed class PasswordHelper
{
    public static string HashPassword(string password) => 
        BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());

    public static bool VerifyPassword(string password = null, string hashedPassword = null)
    {
        if (password is null || hashedPassword is null)
            return false;

        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
        
}
