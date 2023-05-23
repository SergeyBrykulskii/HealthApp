using HealthApp.Application.Abstractions;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Entities;
using System.Linq.Expressions;

namespace HealthApp.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IUnitOfWork _unitOfWork;

    public DoctorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task AddAsync(Doctor entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.DoctorRepository.AddAsync(entity, cancellationToken);
    }

    public Task DeleteAsync(Doctor entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.DoctorRepository.DeleteAsync(entity, cancellationToken);
    }

    public Task<Doctor> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.DoctorRepository.GetByIdAsync(id, cancellationToken);
    }

    public Task<bool> IsExistsAsync(Expression<Func<Doctor, bool>> filter, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.DoctorRepository.IsExistsAsync(filter, cancellationToken);
    }

    public Task<IReadOnlyList<Doctor>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return _unitOfWork.DoctorRepository.ListAllAsync(cancellationToken);
    }

    public Task<Doctor> FirstOrDefaultAsync(Expression<Func<Doctor, bool>> filter, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.DoctorRepository.FirstOrDefaultAsync(filter, cancellationToken);
    }
    public Task UpdateAsync(Doctor entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.DoctorRepository.UpdateAsync(entity, cancellationToken);
    }

    public Task SaveAllAsync()
    {
        return _unitOfWork.SaveAllAsync();
    }
}
