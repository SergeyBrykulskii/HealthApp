using HealthApp.Domain.Entities;

namespace HealthApp.Domain.Abstractions;

public interface ICardRepository : IBaseRepository<Card>
{
    Task<IReadOnlyList<Record>> GetListOfRecordsAsync(int cardId);
}
