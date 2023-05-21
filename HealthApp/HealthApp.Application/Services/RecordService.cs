using HealthApp.Application.Abstractions;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Entities;
using System.Linq.Expressions;

namespace HealthApp.Application.Services;

public class RecordService : IRecordService
{
    private readonly IUnitOfWork _unitOfWork;

    public RecordService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task AddAsync(Record entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.RecordRepository.AddAsync(entity, cancellationToken);
    }

    public Task DeleteAsync(Record entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.RecordRepository.DeleteAsync(entity, cancellationToken);
    }

    public Task<Record> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.RecordRepository.GetByIdAsync(id, cancellationToken);
    }

    public Task<bool> IsExistsAsync(Expression<Func<Record, bool>> filter, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.RecordRepository.IsExistsAsync(filter, cancellationToken);
    }

    public Task<IReadOnlyList<Record>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return _unitOfWork.RecordRepository.ListAllAsync(cancellationToken);
    }

    public Task<Record> FirstOrDefaultAsync(Expression<Func<Record, bool>> filter, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.RecordRepository.FirstOrDefaultAsync(filter, cancellationToken);
    }
    public Task UpdateAsync(Record entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.RecordRepository.UpdateAsync(entity, cancellationToken);
    }
}
