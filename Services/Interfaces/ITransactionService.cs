using CrossCutting.Dtos.Transaction;

namespace Services.Interfaces
{
    public interface ITransactionService
    {
        TransactionReadDto CreateTransaction(Guid accountId, TransactionCreateDto transaction);
        TransactionAccountReadDto GetTransactionsByAccount(Guid accountId);
        TransactionReadDto? RevertTransaction(Guid accountId, Guid transactionId);
    }
}
