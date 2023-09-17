using Domain.Entities;

namespace Data.Interfaces
{
    public interface IAccountRepository
    {
        void CreateAccount(Account account);

        Account? GetAccountById(Guid peopleId, Guid id);

        IEnumerable<Account> GetAllAccounts(Guid peopleId);
    }
}
