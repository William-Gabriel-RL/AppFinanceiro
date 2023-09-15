using Data.Context;
using Data.Interfaces;

namespace Data.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly AppFinanceiroContext _context;

        public CardRepository(AppFinanceiroContext context)
        {
            _context = context;
        }
    }
}
