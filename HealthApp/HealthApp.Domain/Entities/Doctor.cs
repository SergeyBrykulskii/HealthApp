namespace HealthApp.Domain.Entities;

public class Doctor : User
{
    public Doctor(string password, string email, string speciality = "", string name = "")
        : base(name, password, email)
    {
        Speciality = speciality;

    }

    public string Speciality { get; set; }
}
