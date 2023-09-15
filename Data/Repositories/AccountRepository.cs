using Data.Context;
using Data.Interfaces;

namespace Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppFinanceiroContext _context;

        public AccountRepository(AppFinanceiroContext context)
        {
            _context = context;
        }
    }
}
