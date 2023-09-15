using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardTypeController : ControllerBase
    {
        private readonly ICardTypeService _service;

        public CardTypeController(ICardTypeService service)
        {
            _service = service;
        }
    }
}
