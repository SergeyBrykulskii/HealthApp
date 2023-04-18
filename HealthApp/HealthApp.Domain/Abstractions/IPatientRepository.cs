using HealthApp.Domain.Entities;

namespace HealthApp.Domain.Abstractions;

public interface IPatientRepository : IBaseRepository<Patient>
{
    Task<Patient> GetByNameAsync(string name);
}
