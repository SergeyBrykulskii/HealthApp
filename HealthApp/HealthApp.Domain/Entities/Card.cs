namespace HealthApp.Domain.Entities;

public class Card
{
    public Card()
    {
        Records = new();
        Info = new();
    }
    public Card(int age, bool male, double weight)
    {
        Records = new();
        Info = new(age, male, weight);
    }
    public void AddRecord(int doctorId, string content, DateTime date)
    {
        Records.Add(new(doctorId, content, date));
    }
    public List<Record> Records { get; set; }
    public int PatientId { get; set; }
    public InformationAboutPatient Info { get; set; }
}
