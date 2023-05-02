using HealthApp.Domain.EntityInterfaces;

namespace HealthApp.Domain.Entities;

public abstract class User : IUser
{
    private static int GlobalId = 0;
    public User(string password, string email)
    {
        Id = GlobalId;
        ++GlobalId;

        Name = string.Empty;
        Password = password;
        Email = email;
    }
    public User(string name, string password, string email)
    {
        Id = GlobalId;
        ++GlobalId;

        Name = name;
        Password = password;
        Email = email;
    }
    public string Name { get; set; }
    public string Password { get; set; }
    public int Id { get; set; }
    public string Email { get; set; }
}
