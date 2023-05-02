using HealthApp.Application.Abstractions.ConsoleApp;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Entities;

namespace HealthApp.Application.Services.ConsoleApp;

public class CardService : ICardService
{
    private readonly IUnitOfWork _unitOfWork;

    public CardService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(Card entity)
    {
        _unitOfWork.CardRepository.Add(entity);
    }

    public void Delete(Card entity)
    {
        _unitOfWork.CardRepository.Delete(entity);
    }

    public Card GetById(int id)
    {
        return _unitOfWork.CardRepository.GetById(id);
    }

    public bool IsExists(Func<Card, bool> filter)
    {
        return _unitOfWork.CardRepository.IsExists(filter);
    }

    public IReadOnlyList<Card> ListAll()
    {
        return _unitOfWork.CardRepository.ListAll();
    }

    public Card FirstOrDefault(Func<Card, bool> filter)
    {
        return _unitOfWork.CardRepository.FirstOrDefault(filter);
    }
    public void Update(Card entity)
    {
        _unitOfWork.CardRepository.Update(entity);
    }
}
