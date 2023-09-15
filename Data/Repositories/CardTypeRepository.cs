using Data.Context;
using Data.Interfaces;
namespace Data.Repositories
{
    public class CardTypeRepository : ICardTypeRepository
    {
        private readonly AppFinanceiroContext _context;

        public CardTypeRepository(AppFinanceiroContext context)
        {
            _context = context;
        }
    }
}
