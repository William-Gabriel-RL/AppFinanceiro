using CrossCutting.Dtos.Transaction;

namespace Services.Interfaces
{
    public interface ITransactionService
    {
        TransactionReadDto CreateTransaction(Guid accountId, TransactionCreateDto transaction);
        TransactionAccountReadDto GetTransactionsByAccount(Guid accountId, int? page, float? resultsPerPage, DateTime? searchedDate);
        TransactionReadDto? RevertTransaction(Guid accountId, Guid transactionId);
    }
}
