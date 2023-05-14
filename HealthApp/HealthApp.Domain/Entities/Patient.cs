namespace HealthApp.Domain.Entities;

public class Patient : User
{
    public Patient(string password, string email, string name = "") : base(name, password, email)
    {
    }
}
