using Data.Context;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppFinanceiroContext _context;

        public TransactionRepository(AppFinanceiroContext context)
        {
            _context = context;
        }

        public void CreateTransaction(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
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
    }
}
