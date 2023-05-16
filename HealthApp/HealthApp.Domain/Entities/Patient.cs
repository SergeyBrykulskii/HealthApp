using SQLite;

namespace HealthApp.Domain.Entities;

[Table("Patients")]
public class Patient : User
{
    public Patient() { }
    public Patient(string password, string email, string name = "") : base(name, password, email)
    {
    }
}
