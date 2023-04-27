using HealthApp.Domain.EntityInterfaces;

namespace HealthApp.Domain.Entities;

public class Card : IEntity
{
    public Card()
    {
        Records = new();
        Info = new();
    }
    public Card(int id, int age, bool male, double weight)
    {
        Id = id;
        Records = new();
        Info = new(age, male, weight);
    }
    public void AddRecord(int doctorId, string content, DateTime date)
    {
        Records.Add(new(doctorId, content, date));
    }
    public int Id { get; set; }
    public List<Record> Records { get; set; }
    public int PatientId { get; set; }
    public InformationAboutPatient Info { get; set; }
}
