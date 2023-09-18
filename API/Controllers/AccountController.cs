using CrossCutting.Dtos.Account;
using CrossCutting.Dtos.Card;
using CrossCutting.Dtos.Transaction;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly ICardService _serviceCard;
        private readonly ITransactionService _serviceTransaction;

        public AccountController(IAccountService service, ICardService serviceCard, ITransactionService serviceTransaction)
        {
            _service = service;
            _serviceCard = serviceCard;
            _serviceTransaction = serviceTransaction;
        }

        [HttpGet("{accountId}/cards")]
        public ActionResult<AccountAndCardReadDto?> GetCardsByAccount(string accountId)
        {
            try
            {
                Guid accountGuid = new(accountId);
                var cards = _service.GetCardsByAccount(accountGuid);
                if (cards != null) return Ok(cards);
                return NotFound();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpPost("{accountId}/cards")]
        public ActionResult<CardReadDto> CreateCard(string accountId, CardCreateDto card)
        {
            try
            {
                Guid accountGuid = new(accountId);
                var newCard = _serviceCard.CreateCard(accountGuid, card);
                return Ok(newCard);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpPost("{accountId}/transactions")]
        public ActionResult<TransactionReadDto> CreateTransaction(string accountId, TransactionCreateDto transaction)
        {
            try
            {
                Guid accountGuid = new(accountId);
                var newTransaction = _serviceTransaction.CreateTransaction(accountGuid, transaction);
                return Ok(newTransaction);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpGet("{accountId}/transactions")]
        public ActionResult<TransactionAccountReadDto> GetTransactionsByAccount(string accountId)
        {
            try
            {
                Guid accountGuid = new(accountId);
                var cards = _serviceTransaction.GetTransactionsByAccount(accountGuid);
                return Ok(cards);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpGet("{accountId}/balance")]
        public ActionResult<AccountBalanceReadDto> GetAccountBalance(string accountId)
        {
            try
            {
                Guid accountGuid = new(accountId);
                var balance = _service.GetAccountBalance(accountGuid);
                return Ok(balance);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpGet("{accountId}/transactions/{transactionId}/revert")]
        public ActionResult<TransactionReadDto> RevertTransaction(string accountId, string transactionId) 
        {
            try
            {
                Guid accountGuid = new(accountId);
                Guid transactionGuid = new(transactionId);
                var revertedTransaction = _serviceTransaction.RevertTransaction(accountGuid, transactionGuid);
                if (revertedTransaction != null)
                    return Ok(revertedTransaction);
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
