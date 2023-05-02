using HealthApp.Domain.EntityInterfaces;

namespace HealthApp.Domain.Abstractions;

public interface IEntityRepository<T> where T : IEntity
{
    T GetById(int id);

    IReadOnlyList<T> ListAll();

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);

    bool IsExists(Func<T, bool> filter);

    T FirstOrDefault(Func<T, bool> filter);
}
