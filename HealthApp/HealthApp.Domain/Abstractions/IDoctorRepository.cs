using HealthApp.Domain.Entities;

namespace HealthApp.Domain.Abstractions;

public interface IDoctorRepository : IBaseRepository<Doctor>
{
    Task<Doctor> GetByNameAsync(string name);
}
