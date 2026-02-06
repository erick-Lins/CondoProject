using CondoProj.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CondoProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Create()
        {
            return Ok();
        }

    }
}
