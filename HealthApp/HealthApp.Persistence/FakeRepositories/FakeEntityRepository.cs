using HealthApp.Domain.Abstractions;
using HealthApp.Domain.EntityInterfaces;

namespace HealthApp.Persistence.FakeRepositories;

public class FakeEntityRepository<T> : IEntityRepository<T> where T : IEntity
{
    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public bool IsExists(Func<T, bool> filter)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<T> ListAll()
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
