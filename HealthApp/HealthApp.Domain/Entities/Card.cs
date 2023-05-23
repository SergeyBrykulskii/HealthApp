using HealthApp.Domain.EntityInterfaces;
using SQLite;

namespace HealthApp.Domain.Entities;

[Table("Cards")]
public class Card : IEntity
{
    public Card() { }
    public Card(int age = 0, bool male = true, double weight = 0)
    {
        Records = new();
        Age = age;
        Male = male;
        Weight = weight;
    }
    public void AddRecord(string content, DateTime date)
    {
        Records.Add(new(content, date));
    }
    public void AddInfo(int age, bool male, double weight)
    {
        Age = age;
        Male = male;
        Weight = weight;
    }
    /*public void AddIllness(string illness)
    {
        Illnesses.Add(illness);
    }*/

    [PrimaryKey, Indexed, AutoIncrement]
    public int Id { get; set; }
    public List<Record> Records { get; set; }
    public Patient Patient { get; set; } = new();
    public int Age { get; set; }
    public bool Male { get; set; }
    public double Weight { get; set; }
    //public List<string> Illnesses { get; set; }
}
