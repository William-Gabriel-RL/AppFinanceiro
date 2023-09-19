using AutoMapper;
using CrossCutting.Dtos.People;
using CrossCutting.Exceptions;
using CrossCutting.Extensions;
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
            try
            {
                if (!people.Document.IsValidCNPJ() || !people.Document.IsValidCPF())
                    throw new InvalidDocumentException();

                var peopleModel = _mapper.Map<People>(people);
                _repository.CreatePeople(peopleModel);

                return _mapper.Map<PeopleReadDto>(peopleModel);
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
