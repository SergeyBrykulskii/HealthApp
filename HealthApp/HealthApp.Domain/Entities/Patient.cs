namespace HealthApp.Domain.Entities;

public class Patient : User
{
    public Patient() : base()
    {
        PhoneNumber = string.Empty;
        Email = string.Empty;
    }
    public Patient(int id, string name, string login, string password, string phoneNumber, string email)
        : base(id, name, login, password)
    {
        PhoneNumber = phoneNumber;
        Email = email;
    }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
