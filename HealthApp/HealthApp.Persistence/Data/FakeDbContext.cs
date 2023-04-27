using HealthApp.Domain.Entities;

namespace HealthApp.Persistence.Data;

public class FakeDbContext : IFakeDbContext
{
    private List<Patient> _patients { get; set; } = new();
    private List<Doctor> _doctors { get; set; } = new();
    private List<Card> _cards { get; set; } = new();

    public IEnumerable<T> GetList<T>()
    {
        throw new NotImplementedException();
    }
}
