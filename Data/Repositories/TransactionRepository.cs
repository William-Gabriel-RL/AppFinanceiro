using Data.Context;
using Data.Interfaces;

namespace Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppFinanceiroContext _context;

        public TransactionRepository(AppFinanceiroContext context)
        {
            _context = context;
        }
    }
}
