using Domain.Entities;

namespace Data.Interfaces
{
    public interface ITransactionRepository
    {
        void CreateTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactionsByAccount(Guid accountId);
        Transaction? GetTransaction(Guid accountId, Guid transactionId);
        void SetTransactionAsReverted(Transaction transaction, Transaction reverseTransaction);
    }
}
