using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _service;

        public PeopleController(IPeopleService service)
        {
            _service = service;
        }
    }
}
