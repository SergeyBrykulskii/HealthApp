namespace HealthApp.Domain.Entities;

public class Doctor : User
{
    public Doctor(string name, string password, string email, string speciality, TimeOnly start, TimeOnly end)
        : base(name, password, email)
    {
        Speciality = speciality;
        WorkingHours = (start, end);
    }
    public Doctor(string password, string email) : base(password, email)
    {
        Speciality = string.Empty;
        WorkingHours = (new TimeOnly(8, 0), new TimeOnly(18, 0));
    }

    public string Speciality { get; set; }
    public (TimeOnly, TimeOnly) WorkingHours { get; set; }
}
