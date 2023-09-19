using CrossCutting.Dtos.Card;

namespace Services.Interfaces
{
    public interface ICardService
    {
        CardReadDto? CreateCard(Guid accountId, CardCreateDto card);
        CardReadDto? GetCardById(Guid accountId, Guid cardId);
        CardsPeopleReadDto GetCardsByPeople(Guid peopleId, int page, float resultsPerPage);
    }
}
