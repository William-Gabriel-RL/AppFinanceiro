using Domain.Entities;

namespace Data.Interfaces
{
    public interface ITransactionRepository
    {
        void CreateTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactionsByAccount(Guid accountId, int page, float resultsPerPage, DateTime? searchedDate);
        Transaction? GetTransaction(Guid accountId, Guid transactionId);
        void SetTransactionAsReverted(Transaction transaction, Transaction reverseTransaction);
    }
}
