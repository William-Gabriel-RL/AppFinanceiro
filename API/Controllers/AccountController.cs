using CrossCutting.Dtos.Account;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("{peopleId}/accounts")]
        public ActionResult<AccountReadDto> CreateAccount(string peopleId, AccountCreateDto account)
        {
            try
            {
                Guid peopleGuid = new(peopleId);
                var newAccount = _service.CreateAccount(peopleGuid, account);
                return CreatedAtRoute(nameof(GetAccountById), new { PeopleId = peopleId, Id = newAccount.IdAccount }, newAccount);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpGet("{peopleId}/accounts/{accountId}", Name = "GetAccountById")]
        public ActionResult<AccountReadDto> GetAccountById(string peopleId, string accountId)
        {
            try
            {
                Guid peopleGuid = new(peopleId);
                Guid accountGuid = new(accountId);
                var account = _service.GetAccountById(peopleGuid, accountGuid);
                if (account != null)
                    return Ok(account);
                return NotFound();
            }
            catch(Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpGet("{peopleId}/accounts")]
        public ActionResult<IEnumerable<AccountReadDto>> GetAllAccounts(string peopleId)
        {
            try
            {
                Guid peoplGuid = new(peopleId);
                var accounts = _service.GetAllAccounts(peoplGuid);
                return Ok(accounts);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

    }
}
