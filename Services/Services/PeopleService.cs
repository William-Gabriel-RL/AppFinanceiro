using Data.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _repository;

        public PeopleService(IPeopleRepository repository)
        {
            _repository = repository;
        }
    }
}
