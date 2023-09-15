using Data.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class CardTypeService : ICardTypeService
    {
        private readonly ICardTypeRepository _repository;

        public CardTypeService(ICardTypeRepository repository)
        {
            _repository = repository;
        }
    }
}
