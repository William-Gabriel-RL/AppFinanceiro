using Data.Context;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly AppFinanceiroContext _context;

        public CardRepository(AppFinanceiroContext context)
        {
            _context = context;
        }

        public void CreateCard(Card card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            _context.Cards.Add(card);
            _context.SaveChanges();
        }

        public Card? GetCardById(Guid accountId, Guid cardId)
        {
            return _context.Cards.FirstOrDefault(c => c.IdAccount == accountId && c.IdCard == cardId);
        }

        public IEnumerable<Card> GetCardsByAccount(Guid accountId)
        {
            return _context.Cards.Where(c => c.IdAccount == accountId);
        }

        public IEnumerable<Card> GetCardsByPeople(Guid peopleId, int page, float resultsPerPage)
        {
            var cards = new List<Card>();
            var accounts = _context.Accounts.Where(a => a.IdPeople == peopleId).ToList();
            foreach (var account in accounts)
            {
                var cardsByAccounts = _context.Cards.Where(c => c.IdAccount == account.IdAccount);
                foreach (var card in cardsByAccounts)
                    cards.Add(card);
            }
            return cards
                .Skip((page -1) * (int)resultsPerPage)
                .Take((int)resultsPerPage);
        }
    }
}
