using Data.Context;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppFinanceiroContext _context;
        private readonly IAccountRepository _accountRepository;

        public TransactionRepository(AppFinanceiroContext context, IAccountRepository accountRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
        }

        public void CreateTransaction(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            try
            {
                _accountRepository.UpdateAccountBalance(transaction.IdAccount, transaction.Value);
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Transaction? GetTransaction(Guid accountId, Guid transactionId)
        {
            return _context.Transactions.FirstOrDefault(t => t.IdAccount == accountId && t.IdTransaction == transactionId);
        }

        public IEnumerable<Transaction> GetTransactionsByAccount(Guid accountId)
        {
            var transactions = _context.Transactions.Where(t => t.IdAccount == accountId).ToList();
            return transactions;
        }

        public void SetTransactionAsReverted(Transaction transaction, Transaction reverseTransaction)
        {
            transaction.IsReverted = true;
            reverseTransaction.IsReverted = true;
            _context.SaveChanges();
        }
    }
}
