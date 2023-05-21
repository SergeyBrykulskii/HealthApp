using HealthApp.Domain.EntityInterfaces;
using SQLite;

namespace HealthApp.Domain.Entities;

[Table("Records")]
public class Record : IEntity
{
    public Record()
    {
        Content = string.Empty;
    }
    public Record(string content, DateTime date)
    {
        Content = content;
        Date = date;
    }

    [PrimaryKey, Indexed, AutoIncrement]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Content { get; set; }

    public Card Card { get; set; } = new();

    public Doctor Doctor { get; set; } = new();
}
