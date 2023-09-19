using CrossCutting.Exceptions;
using Data.Context;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppFinanceiroContext _context;

        public AccountRepository(AppFinanceiroContext context)
        {
            _context = context;
        }

        public void CreateAccount(Account account)
        {
            if (account == null) throw new AccountNotFoundException();

            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public Account? GetAccountBalance(Guid accountGuid)
        {
            return _context.Accounts.FirstOrDefault(a => a.IdAccount ==  accountGuid);
        }

        public Account? GetAccountById(Guid peopleId, Guid id)
        {
            return _context.Accounts.FirstOrDefault(a => a.IdPeople == peopleId && a.IdAccount == id);
        }

        public IEnumerable<Account> GetAllAccounts(Guid peopleId)
        {
            return _context.Accounts.Where(a => a.IdPeople == peopleId);
        }

        public Tuple<IEnumerable<Card>, Account?> GetCardsByAccount(Guid accountId)
        {
            Account? account = _context.Accounts.FirstOrDefault(a => a.IdAccount == accountId);
            var cards = new List<Card>().AsEnumerable();

            if (account != null)
                cards = _context.Cards.Where(c => c.IdAccount == accountId).AsEnumerable();

            return Tuple.Create( cards, account);
        }

        public void UpdateAccountBalance(Guid accountGuid, decimal value)
        {
            Account? account = _context.Accounts.FirstOrDefault(a => a.IdAccount == accountGuid);
            if (account != null)
            {
                var novoBalanco = account.Balance + value;
                if (novoBalanco >= 0)
                {
                    account.Balance = novoBalanco;
                    _context.SaveChanges();
                }
                else
                    throw new InvalidAccountUpdateException();

            }
            else
                throw new AccountNotFoundException();
            
        }
    }
}
