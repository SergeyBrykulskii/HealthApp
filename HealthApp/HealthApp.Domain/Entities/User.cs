namespace HealthApp.Domain.Entities;

public class User
{
    public User()
    {
        Name = string.Empty;
        Login = string.Empty;
        Password = string.Empty;
    }
    public User(int id, string name, string login, string password)
    {
        Id = id;
        Name = name;
        Login = login;
        Password = password;
    }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public int Id { get; set; }
}
