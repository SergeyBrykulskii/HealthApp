using HealthApp.Domain.Entities;

namespace HealthApp.Persistence.Data;

public class FakeDbContext : IFakeDbContext
{
    public List<Patient> _patients { get; set; } = new();
    public List<Doctor> _doctors { get; set; } = new();
    public List<Card> _cards { get; set; } = new();
}
