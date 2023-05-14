using HealthApp.Domain.EntityInterfaces;

namespace HealthApp.Domain.Entities;

public class Card : IEntity
{
    public Card(int id, int age = 0, bool male = true, double weight = 0)
    {
        Id = id;
        Records = new();
        Info = new(age, male, weight);
    }
    public void AddRecord(int doctorId, string content, DateTime date)
    {
        Records.Add(new(doctorId, content, date));
    }
    public void AddInfo(int age, bool male, double weight)
    {
        Info.Age = age;
        Info.Male = male;
        Info.Weight = weight;
    }
    public int Id { get; set; }
    public List<Record> Records { get; set; }
    public int PatientId { get; set; }
    public InformationAboutPatient Info { get; set; }
}
