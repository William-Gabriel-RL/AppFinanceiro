using CrossCutting.Dtos.Account;
using CrossCutting.Dtos.Card;
using CrossCutting.Dtos.Transaction;
using CrossCutting.Exceptions;
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
            catch (FormatException)
            {
                return UnprocessableEntity();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("{accountId}/cards")]
        public ActionResult<CardReadDto?> CreateCard(string accountId, CardCreateDto card)
        {
            try
            {
                Guid accountGuid = new(accountId);
                var newCard = _serviceCard.CreateCard(accountGuid, card);
                if (newCard != null)
                    return Ok(newCard);
                return BadRequest("The infomed PeopleId already own one physical card and this is the max physical cards permited");
            }
            catch (FormatException)
            {
                return UnprocessableEntity();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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
            catch (InvalidAccountUpdateException)
            {
                return BadRequest("It's not possible to set the balance below zero");
            }
            catch (AccountNotFoundException)
            {
                return BadRequest("The provided account does not exists");
            }
            catch (FormatException)
            {
                return UnprocessableEntity();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{accountId}/transactions")]
        public ActionResult<TransactionAccountReadDto> GetTransactionsByAccount(string accountId, int? page, float? resultsPerPage, DateTime? searchedDate)
        {
            try
            {
                Guid accountGuid = new(accountId);
                var cards = _serviceTransaction.GetTransactionsByAccount(accountGuid, page, resultsPerPage, searchedDate);
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
            catch (FormatException)
            {
                return UnprocessableEntity();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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
            catch (FormatException)
            {
                return UnprocessableEntity();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
