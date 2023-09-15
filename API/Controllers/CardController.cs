using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _service;

        public CardController(ICardService service)
        {
            _service = service;
        }
    }
}
