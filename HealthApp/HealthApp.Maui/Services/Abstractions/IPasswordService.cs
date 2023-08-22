namespace HealthApp.Maui.Services.Abstractions;

public interface IPasswordService
{
    public byte[] GetHashedPassword(string password);
    public bool VerifyPassword(string password, byte[] hashedPassword);
}
