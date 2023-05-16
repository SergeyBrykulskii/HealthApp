using SQLite;

namespace HealthApp.Domain.Entities;

[Table("Doctor")]
public class Doctor : User
{
    public Doctor() { }
    public Doctor(string password, string email, string speciality = "", string name = "")
        : base(name, password, email)
    {
        Speciality = speciality;

    }

    public string Speciality { get; set; }
}
