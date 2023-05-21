using HealthApp.Domain.EntityInterfaces;
using SQLite;

namespace HealthApp.Domain.Entities;

[Table("Cards")]
public class Card : IEntity
{
    public Card(int age = 0, bool male = true, double weight = 0)
    {
        Records = new();
        Info = new(age, male, weight);
    }
    public void AddRecord(string content, DateTime date)
    {
        Records.Add(new(content, date));
    }
    public void AddInfo(int age, bool male, double weight)
    {
        Info.Age = age;
        Info.Male = male;
        Info.Weight = weight;
    }
    [PrimaryKey, Indexed, AutoIncrement]
    public int Id { get; set; }
    public List<Record> Records { get; set; }
    public Patient Patient { get; set; } = new();
    public InformationAboutPatient Info { get; set; }
}
