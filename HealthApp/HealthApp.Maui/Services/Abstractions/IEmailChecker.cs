namespace HealthApp.Maui.Services.Abstractions;

public interface IEmailChecker
{
    bool IsValid(string email);
}
