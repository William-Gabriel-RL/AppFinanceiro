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
            try
            {
                var transactionModel = _mapper.Map<Transaction>(transaction);
                transactionModel.IdAccount = accountId;

                _repository.CreateTransaction(transactionModel);

                return _mapper.Map<TransactionReadDto>(transactionModel);
            }
            catch
            {
                throw;
            }
        }

        public TransactionAccountReadDto GetTransactionsByAccount(Guid accountId, int? page, float? resultsPerPage, DateTime? searchedDate)
        {
            try
            {
                if (page == null || page <= 0)
                    page = 1;

                if (resultsPerPage == null || resultsPerPage <= 0)
                    resultsPerPage = 5f;

                TransactionAccountReadDto transactionList = new();
                transactionList.Pagination.CurrentPage = (int)page;
                transactionList.Pagination.ItemsPerPage = (int)resultsPerPage;

                var transactions = _repository.GetTransactionsByAccount(accountId, (int)page, (int)resultsPerPage, searchedDate);
                if (transactions != null)
                    transactionList.Transactions = _mapper.Map<IEnumerable<TransactionReadDto>>(transactions);
                return transactionList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TransactionReadDto? RevertTransaction(Guid accountId, Guid transactionId)
        {
            try
            {
                var transaction = _repository.GetTransaction(accountId, transactionId);
                if (transaction != null)
                {
                    if (transaction.IsReverted == false)
                    {
                        Transaction reverseTransaction = new()
                        {
                            Value = transaction.Value * -1,
                            IdAccount = transaction.IdAccount,
                            Description = "Estorno de cobrança indevida."
                        };
                        _repository.CreateTransaction(reverseTransaction);
                        _repository.SetTransactionAsReverted(transaction, reverseTransaction);
                        return _mapper.Map<TransactionReadDto>(reverseTransaction);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}