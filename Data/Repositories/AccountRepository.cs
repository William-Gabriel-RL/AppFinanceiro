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
            if (account == null) throw new ArgumentNullException(nameof(account));

            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public Account? GetAccountById(Guid peopleId, Guid id)
        {
            return _context.Accounts.FirstOrDefault(a => a.IdPeople == peopleId && a.IdAccount == id);
        }

        public IEnumerable<Account> GetAllAccounts(Guid peopleId)
        {
            return _context.Accounts.Where(a => a.IdPeople == peopleId);
        }
    }
}
