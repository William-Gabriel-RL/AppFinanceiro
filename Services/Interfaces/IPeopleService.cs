using CrossCutting.Dtos.People;

namespace Services.Interfaces
{
    public interface IPeopleService
    {
        PeopleReadDto CreatePeople(PeopleCreateDto people);
    }
}