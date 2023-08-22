using SQLite;

namespace HealthApp.Domain.Entities;

[Table("Patients")]
public class Patient : User
{
    public Patient() { }
    public Patient(byte[] password, string email, string name = "") : base(name, password, email)
    {
    }
}
