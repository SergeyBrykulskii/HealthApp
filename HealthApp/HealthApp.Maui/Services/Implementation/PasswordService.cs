using HealthApp.Maui.Services.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace HealthApp.Maui.Services.Implementation;

public class PasswordService : IPasswordService
{
    private const int SaltSize = 32;
    public string GetHashedPassword(string password)
    {
        var sha512 = SHA512.Create();
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var saltedPassword = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
        var hashedPassword = sha512.ComputeHash(saltedPassword);

        return string.Join("", Convert.ToBase64String(salt), Convert.ToBase64String(hashedPassword));
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var salt = Convert.FromBase64String(hashedPassword.Substring(0, SaltSize));
        var hash = Convert.FromBase64String(hashedPassword.Substring(SaltSize));
        var sha512 = SHA512.Create();
        var saltedPassword = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
        var computedHash = sha512.ComputeHash(saltedPassword);
        return hash.SequenceEqual(computedHash);
    }
}
