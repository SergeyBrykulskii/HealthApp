/*using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Entities;
using HealthApp.Domain.EntityInterfaces;
using HealthApp.Persistence.Data;

namespace HealthApp.Persistence.FakeRepositories;

public class FakeEntityRepository<T> : IEntityRepository<T> where T : IEntity
{
    protected readonly IFakeDbContext _context;
    protected readonly List<T> _entities;

    public FakeEntityRepository(IFakeDbContext fakeDbContext)
    {
        _context = fakeDbContext;
        var type = typeof(T);
        if (type == typeof(Patient))
        {
            _entities = (_context._patients as List<T>)!;
        }
        else if (type == typeof(Doctor))
        {
            _entities = (_context._doctors as List<T>)!;
        }
        else if (type == typeof(Card))
        {
            _entities = (_context._cards as List<T>)!;
        }
        else
        {
            _entities = new List<T>();
        }
    }
    public void Add(T entity)
    {
        _entities.Add(entity);
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }

    public T GetById(int id)
    {
        return _entities.FirstOrDefault(entity => entity.Id == id);
    }

    public bool IsExists(Func<T, bool> filter)
    {
        return _entities.Any(filter);
    }

    public IReadOnlyList<T> ListAll()
    {
        return _entities;
    }

    public void Update(T entity)
    {
        var index = _entities.FindIndex(e => e.Id == entity.Id);
        if (index != -1)
        {
            _entities[index] = entity;
        }
    }

    public T FirstOrDefault(Func<T, bool> filter)
    {
        return _entities.FirstOrDefault(filter)!;
    }
}
*/