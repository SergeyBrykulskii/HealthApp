/*using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Entities;
using HealthApp.Persistence.Data;
using HealthApp.Persistence.FakeRepositories;

namespace HealthApp.Persistence.FakeUnitOfWork;

public class FakeUnitOfWork : IUnitOfWork
{
    private readonly IFakeDbContext _fakeDbContext;
    private readonly Lazy<IEntityRepository<Patient>> _patientsRepository;
    private readonly Lazy<IEntityRepository<Doctor>> _doctorsRepository;
    private readonly Lazy<IEntityRepository<Card>> _cardsRepository;
    public IEntityRepository<Doctor> DoctorRepository => _doctorsRepository.Value;

    public IEntityRepository<Patient> PatientRepository => _patientsRepository.Value;

    public IEntityRepository<Card> CardRepository => _cardsRepository.Value;

    public FakeUnitOfWork(IFakeDbContext fakeDbContext)
    {
        _fakeDbContext = fakeDbContext;
        _patientsRepository = new Lazy<IEntityRepository<Patient>>(() => new FakeEntityRepository<Patient>(_fakeDbContext));
        _doctorsRepository = new Lazy<IEntityRepository<Doctor>>(() => new FakeEntityRepository<Doctor>(_fakeDbContext));
        _cardsRepository = new Lazy<IEntityRepository<Card>>(() => new FakeEntityRepository<Card>(_fakeDbContext));
    }
}
*/