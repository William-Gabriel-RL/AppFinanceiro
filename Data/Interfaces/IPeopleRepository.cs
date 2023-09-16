using Domain.Entities;

namespace Data.Interfaces
{
    public interface IPeopleRepository
    {
        void CreatePeople(People people);

        People? GetPeopleById(Guid id);
    }
}
