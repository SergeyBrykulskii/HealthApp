using HealthApp.Application.Abstractions;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Entities;
using System.Linq.Expressions;

namespace HealthApp.Application.Services;

public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;

    public PatientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task AddAsync(Patient entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PatientRepository.AddAsync(entity, cancellationToken);
    }

    public Task DeleteAsync(Patient entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PatientRepository.DeleteAsync(entity, cancellationToken);
    }

    public Task<Patient> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PatientRepository.GetByIdAsync(id, cancellationToken);
    }

    public Task<bool> IsExistsAsync(Expression<Func<Patient, bool>> filter, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PatientRepository.IsExistsAsync(filter, cancellationToken);
    }

    public Task<IReadOnlyList<Patient>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PatientRepository.ListAllAsync(cancellationToken);
    }

    public Task<Patient> FirstOrDefaultAsync(Expression<Func<Patient, bool>> filter, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PatientRepository.FirstOrDefaultAsync(filter, cancellationToken);
    }
    public Task UpdateAsync(Patient entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PatientRepository.UpdateAsync(entity, cancellationToken);
    }
}
