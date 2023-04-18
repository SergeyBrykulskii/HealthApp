namespace HealthApp.Domain.Entities;

public class Doctor : User
{
    public Doctor() : base()
    {
        Speciality = string.Empty;
        WorkingHours = (new TimeOnly(8, 0), new TimeOnly(16, 0));
    }
    public Doctor(int id, string name, string login, string password, string speciality, TimeOnly start, TimeOnly end)
        : base(id, name, login, password)
    {
        Speciality = speciality;
        WorkingHours = (start, end);
    }
    public string Speciality { get; set; }
    public (TimeOnly, TimeOnly) WorkingHours { get; set; }
}
