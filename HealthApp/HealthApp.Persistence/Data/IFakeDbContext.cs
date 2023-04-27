namespace HealthApp.Persistence.Data;

public interface IFakeDbContext
{
    IEnumerable<T> GetList<T>();
}
