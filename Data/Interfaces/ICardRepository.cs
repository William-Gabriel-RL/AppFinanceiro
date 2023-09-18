using Domain.Entities;

namespace Data.Interfaces
{
    public interface ICardRepository
    {
        void CreateCard(Card card);
        Card? GetCardById(Guid accountId, Guid cardId);
        IEnumerable<Card> GetCardsByPeople(Guid peopleId);
    }
}