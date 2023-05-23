namespace HealthApp.Maui.Services.Abstractions;

public interface IPasswordService
{
    public string GetHashedPassword(string password);
    public bool VerifyPassword(string password, string hashedPassword);
}
