using CrossCutting.Dtos.Account;
using CrossCutting.Dtos.Card;
using CrossCutting.Dtos.People;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _service;
        private readonly IAccountService _serviceAccount;
        private readonly ICardService _serviceCards;

        public PeopleController(IPeopleService service, IAccountService serviceAccount, ICardService serviceCards)
        {
            _service = service;
            _serviceAccount = serviceAccount;
            _serviceCards = serviceCards;
        }

        [HttpPost]
        public ActionResult<PeopleReadDto> CreatePeople(PeopleCreateDto people)
        {
            var peopleReadDto = _service.CreatePeople(people);
            return Ok(peopleReadDto);
        }

        [HttpPost("{peopleId}/accounts")]
        public ActionResult<AccountReadDto> CreateAccount(string peopleId, AccountCreateDto account)
        {
            try
            {
                Guid peopleGuid = new(peopleId);
                var newAccount = _serviceAccount.CreateAccount(peopleGuid, account);
                return Ok(newAccount);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpGet("{peopleId}/accounts")]
        public ActionResult<IEnumerable<AccountReadDto>> GetAccountsByPeopleId(string peopleId) 
        {
            try
            {
                Guid peopleGuid = new(peopleId);
                var accounts = _serviceAccount.GetAllAccounts(peopleGuid);
                return Ok(accounts);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpGet("{peopleId}/cards")]
        public ActionResult<CardsPeopleReadDto> GetCardsByPeopleId(string peopleId)
        {
            try
            {
                Guid peopleGuid = new(peopleId);
                var cards = _serviceCards.GetCardsByPeople(peopleGuid);
                return Ok(cards);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }
    }
}
