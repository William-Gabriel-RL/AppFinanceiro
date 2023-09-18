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

        public CardReadDto CreateCard(Guid accountId, CardCreateDto card)
        {
            var cardModel = _mapper.Map<Card>(card);
            cardModel.IdAccount = accountId;

            _repository.CreateCard(cardModel);

            return _mapper.Map<CardReadDto>(cardModel);
        }

        public CardReadDto? GetCardById(Guid accountId, Guid cardId)
        {
            var card = _repository.GetCardById(accountId, cardId);
            if (card == null)
                return null;
            return _mapper.Map<CardReadDto>(card);
        }

        public CardsPeopleReadDto GetCardsByPeople(Guid peopleId)
        {
            CardsPeopleReadDto listaCards = new();
            var cards = _repository.GetCardsByPeople(peopleId);
            if (cards != null)
                listaCards.Cards = _mapper.Map<IEnumerable<CardReadDto>>(cards);
            return listaCards;
        }
    }
}
