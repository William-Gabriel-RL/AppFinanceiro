using Data.Context;
using Data.Interfaces;

namespace Data.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppFinanceiroContext _context;

        public PeopleRepository(AppFinanceiroContext context)
        {
            _context = context;
        }
    }
}
