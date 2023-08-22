using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Entities;
using HealthApp.Persistence.Data;
using HealthApp.Persistence.Repository;

namespace HealthApp.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbontext;
    private readonly Lazy<IEntityRepository<Patient>> _patientsRepository;
    private readonly Lazy<IEntityRepository<Doctor>> _doctorsRepository;
    private readonly Lazy<IEntityRepository<Card>> _cardsRepository;
    private readonly Lazy<IEntityRepository<Record>> _recordsRepository;

    public UnitOfWork(AppDbContext appDbontext)
    {
        _appDbontext = appDbontext;
        _patientsRepository = new Lazy<IEntityRepository<Patient>>(() => new EfRepository<Patient>(_appDbontext));
        _doctorsRepository = new Lazy<IEntityRepository<Doctor>>(() => new EfRepository<Doctor>(_appDbontext));
        _cardsRepository = new Lazy<IEntityRepository<Card>>(() => new EfRepository<Card>(_appDbontext));
        _recordsRepository = new Lazy<IEntityRepository<Record>>(() => new EfRepository<Record>(_appDbontext));
    }
    public IEntityRepository<Doctor> DoctorRepository => _doctorsRepository.Value;
    public IEntityRepository<Patient> PatientRepository => _patientsRepository.Value;
    public IEntityRepository<Card> CardRepository => _cardsRepository.Value;
    public IEntityRepository<Record> RecordRepository => _recordsRepository.Value;

    public async Task RemoveDatbaseAsync()
    {
        await _appDbontext.Database.EnsureDeletedAsync();
    }
    public async Task CreateDatabaseAsync()
    {
        await _appDbontext.Database.EnsureCreatedAsync();
    }
    public async Task SaveAllAsync()
    {
        await _appDbontext.SaveChangesAsync();
    }
}
