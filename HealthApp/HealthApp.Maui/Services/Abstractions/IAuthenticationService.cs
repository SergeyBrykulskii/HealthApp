using HealthApp.Domain.Entities;

namespace HealthApp.Maui.Services.Abstractions;

public interface IAuthenticationService
{
    public Task<User> LoginAsync(string email, string password);
}
