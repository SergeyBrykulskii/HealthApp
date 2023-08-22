using HealthApp.Maui.Services.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace HealthApp.Maui.Services.Implementation;

public class PasswordService : IPasswordService
{
    private const int SaltSize = 32;

    public byte[] GetHashedPassword(string password)
    {
        var sha512 = SHA512.Create();
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var saltedPassword = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
        var hashedPassword = sha512.ComputeHash(saltedPassword);
        return salt.Concat(hashedPassword).ToArray();
    }

    public bool VerifyPassword(string password, byte[] hashedPassword)
    {
        var salt = hashedPassword.Take(SaltSize).ToArray();
        var hash = hashedPassword.Skip(SaltSize).ToArray();
        var sha512 = SHA512.Create();
        var saltedPassword = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
        var computedHash = sha512.ComputeHash(saltedPassword);
        return hash.SequenceEqual(computedHash);
    }
}
