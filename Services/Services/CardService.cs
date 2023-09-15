using Data.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _repository;

        public CardService(ICardRepository repository)
        {
            _repository = repository;
        }
    }
}
