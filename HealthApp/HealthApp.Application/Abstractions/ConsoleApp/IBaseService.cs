using HealthApp.Domain.EntityInterfaces;

namespace HealthApp.Application.Abstractions.ConsoleApp;

public interface IBaseService<T> where T : IEntity
{
    T GetById(int id);

    IReadOnlyList<T> ListAll();

    T FirstOrDefault(Func<T, bool> filter);

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);
    bool IsExists(Func<T, bool> filter);
}
