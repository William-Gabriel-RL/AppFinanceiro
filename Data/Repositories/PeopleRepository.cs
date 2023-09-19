using CrossCutting.Exceptions;
using Data.Context;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppFinanceiroContext _context;

        public PeopleRepository(AppFinanceiroContext context)
        {
            _context = context;
        }

        public void CreatePeople(People people)
        {
            if (people == null) throw new ArgumentNullException(nameof(people));

            if (_context.Peoples.Where(p => p.Document == people.Document).Any())
                throw new PeopleAlreadyCreatedException();

            _context.Peoples.Add(people);
            _context.SaveChanges();
        }
    }
}
