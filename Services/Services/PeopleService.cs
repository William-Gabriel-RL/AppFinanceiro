using AutoMapper;
using CrossCutting.Dtos.People;
using Data.Interfaces;
using Domain.Entities;
using Services.Interfaces;

namespace Services.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _repository;
        private readonly IMapper _mapper;

        public PeopleService(IPeopleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public PeopleReadDto CreatePeople(PeopleCreateDto people)
        {
            var peopleModel = _mapper.Map<People>(people);
            _repository.CreatePeople(peopleModel);

            return _mapper.Map<PeopleReadDto>(peopleModel);
        }

        public PeopleReadDto? GetPeopleById(Guid id)
        {
            var people = _repository.GetPeopleById(id);
            if (people != null)
                return _mapper.Map<PeopleReadDto>(people);

            return null;
        }
    }
}
