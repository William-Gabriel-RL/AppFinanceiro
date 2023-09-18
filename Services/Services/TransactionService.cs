using AutoMapper;
using CrossCutting.Dtos.Transaction;
using Data.Interfaces;
using Domain.Entities;
using Services.Interfaces;

namespace Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public TransactionReadDto CreateTransaction(Guid accountId, TransactionCreateDto transaction)
        {
            var transactionModel = _mapper.Map<Transaction>(transaction);
            transactionModel.IdAccount = accountId;

            _repository.CreateTransaction(transactionModel);

            return _mapper.Map<TransactionReadDto>(transactionModel);
        }

        public TransactionAccountReadDto GetTransactionsByAccount(Guid accountId)
        {
            TransactionAccountReadDto transactionList = new();
            var transactions = _repository.GetTransactionsByAccount(accountId);
            if (transactions != null)
                transactionList.Transactions = _mapper.Map<IEnumerable<TransactionReadDto>>(transactions);
            return transactionList;
        }

        public TransactionReadDto? RevertTransaction(Guid accountId, Guid transactionId)
        {
            var transaction = _repository.GetTransaction(accountId, transactionId);
            if (transaction != null)
            {
                Transaction reverseTransaction = new()
                {
                    Value = transaction.Value * -1,
                    IdAccount = transaction.IdAccount,
                    Description = "Estorno de cobrança indevida."
                };
                _repository.CreateTransaction(reverseTransaction);
                return _mapper.Map<TransactionReadDto>(reverseTransaction);
            }
            return null;
        }
    }
}