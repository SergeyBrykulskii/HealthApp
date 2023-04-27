namespace HealthApp.Domain.Entities;

public class Doctor : User
{
    public Doctor(string name, string password, string email, string speciality, TimeOnly start, TimeOnly end)
        : base(name, password, email)
    {
        Speciality = speciality;
        WorkingHours = (start, end);
    }

    public string Speciality { get; set; }
    public (TimeOnly, TimeOnly) WorkingHours { get; set; }
}
