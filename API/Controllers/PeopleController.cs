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

        public PeopleController(IPeopleService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<PeopleReadDto> CreatePeople(PeopleCreateDto people)
        {
            var peopleReadDto = _service.CreatePeople(people);
            return CreatedAtRoute(nameof(GetPeopleById), new {Id = peopleReadDto.IdPeople}, peopleReadDto);
        }

        [HttpGet(Name = "GetPeopleById")]
        public ActionResult<PeopleReadDto?> GetPeopleById(string id)
        {
            try
            {
                Guid guid = new(id);
                var people = _service.GetPeopleById(guid);
                if (people == null)
                    return NotFound();

                return Ok(people);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }
    }
}
