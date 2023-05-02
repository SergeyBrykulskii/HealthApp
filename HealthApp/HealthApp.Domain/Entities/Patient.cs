namespace HealthApp.Domain.Entities;

public class Patient : User
{
    public Patient(string name, string password, string email) : base(name, password, email)
    {
    }
    public Patient(string password, string email) : base(password, email) { }
}
