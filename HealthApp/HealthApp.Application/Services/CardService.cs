using HealthApp.Application.Abstractions;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Entities;
using System.Linq.Expressions;

namespace HealthApp.Application.Services;

public class CardService : ICardService
{
    private readonly IUnitOfWork _unitOfWork;

    public CardService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task AddAsync(Card entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.CardRepository.AddAsync(entity, cancellationToken);
    }

    public Task DeleteAsync(Card entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.CardRepository.DeleteAsync(entity, cancellationToken);
    }

    public Task<Card> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.CardRepository.GetByIdAsync(id, cancellationToken);
    }

    public Task<bool> IsExistsAsync(Expression<Func<Card, bool>> filter, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.CardRepository.IsExistsAsync(filter, cancellationToken);
    }

    public Task<IReadOnlyList<Card>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return _unitOfWork.CardRepository.ListAllAsync(cancellationToken);
    }

    public Task<Card> FirstOrDefaultAsync(Expression<Func<Card, bool>> filter, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.CardRepository.FirstOrDefaultAsync(filter, cancellationToken);
    }
    public Task UpdateAsync(Card entity, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.CardRepository.UpdateAsync(entity, cancellationToken);
    }
}
