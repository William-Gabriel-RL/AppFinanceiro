using AutoMapper;
using CrossCutting.Dtos.People;
using Domain.Entities;

namespace CrossCutting.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<People, PeopleReadDto>();
            CreateMap<PeopleCreateDto, People>();
        }
    }
}