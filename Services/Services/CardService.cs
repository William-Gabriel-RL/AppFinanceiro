using AutoMapper;
using CrossCutting.Dtos.Card;
using Data.Interfaces;
using Domain.Entities;
using Services.Interfaces;

namespace Services.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _repository;
        private readonly IMapper _mapper;

        public CardService(ICardRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CardReadDto? CreateCard(Guid accountId, CardCreateDto card)
        {
            try
            {
                var cardModel = _mapper.Map<Card>(card);
                cardModel.IdAccount = accountId;

                var peopleCards = _repository.GetCardsByAccount(accountId).ToList();

                foreach (var peopleCard in peopleCards)
                {
                    if (peopleCard.Type == "physical")
                        return null;
                }

                _repository.CreateCard(cardModel);

                return _mapper.Map<CardReadDto>(cardModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CardReadDto? GetCardById(Guid accountId, Guid cardId)
        {
            try
            {
                var card = _repository.GetCardById(accountId, cardId);
                if (card == null)
                    return null;
                return _mapper.Map<CardReadDto>(card);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CardsPeopleReadDto GetCardsByPeople(Guid peopleId, int page, float resultsPerPage)
        {
            try
            {
                if (resultsPerPage <= 0)
                    resultsPerPage = 5f;

                if (page <= 0)
                    page = 1;

                CardsPeopleReadDto listaCards = new();
                listaCards.Pagination.ItemsPerPage = (int)resultsPerPage;
                listaCards.Pagination.CurrentPage = page;

                var cards = _repository.GetCardsByPeople(peopleId, page, resultsPerPage);
                if (cards != null)
                    listaCards.Cards = _mapper.Map<IEnumerable<CardReadDto>>(cards);
                return listaCards;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
