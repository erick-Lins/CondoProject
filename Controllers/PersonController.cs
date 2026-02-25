using CondoProj.Interfaces;
using CondoProj.Model;
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

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (person == null)
                return BadRequest("Body request shouldn't be null.");

            var result = _service.Create(person);

            if (!result.Success || !ModelState.IsValid)
                return BadRequest(result.ErrorMessage);

            return CreatedAtAction(nameof(GetById), new { id = person.PersonId}, person);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (result == null)
                return NotFound($"The person of id: {id} was not found.");

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Person newPerson)
        {
            if (newPerson == null)
                return NotFound($"ID: {id} is invalid");

            var result = _service.UpdatePerson(id, newPerson);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return NoContent();
        }

    }
}
