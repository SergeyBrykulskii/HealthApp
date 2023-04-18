namespace HealthApp.Domain.Entities;

public class Record
{
    public Record()
    {
        Content = string.Empty;
    }
    public Record(int doctorId, string content, DateTime date)
    {
        DoctorId = doctorId;
        Content = content;
        Date = date;
    }
    public DateTime Date { get; set; }
    public string Content { get; set; }
    public int DoctorId { get; set; }
}
