using HealthApp.Domain.Entities;

namespace HealthApp.Domain.Abstractions;

public interface IUnitOfWork
{
    IEntityRepository<Doctor> DoctorRepository { get; }
    IEntityRepository<Patient> PatientRepository { get; }
    IEntityRepository<Card> CardRepository { get; }
    IEntityRepository<Record> RecordRepository { get; }

    public Task RemoveDatbaseAsync();
    public Task CreateDatabaseAsync();
    public Task SaveAllAsync();
}
