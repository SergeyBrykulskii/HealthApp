using HealthApp.Domain.EntityInterfaces;
using SQLite;

namespace HealthApp.Domain.Entities;

public abstract class User : IUser
{
    protected User() { }
    protected User(string password, string email)
    {
        Name = string.Empty;
        Password = password;
        Email = email;
    }
    protected User(string name, string password, string email)
    {
        Name = name;
        Password = password;
        Email = email;
    }
    public string Name { get; set; }
    public string Password { get; set; }

    [PrimaryKey, Indexed, AutoIncrement]
    public int Id { get; set; }
    public string Email { get; set; }
}
