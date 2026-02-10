using Microsoft.AspNetCore.Mvc;
using CondoProj.Interfaces;
using CondoProj.Model;

namespace CondoProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _service;

        public ApartmentController(IApartmentService service)
        {
            _service = service;

        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (result == null)
                return NotFound($"Apartment of id: {id} was not found.");

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create(Apartment apartment)
        {
            if (apartment == null)
                return BadRequest("Body request shouldn't be null.");

            var result = _service.Create(apartment);

            if (!result.Success || !ModelState.IsValid)
                return BadRequest(result.ErrorMessage);

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Apartment updatedAparment)
        {
            if (updatedAparment == null)
                return NotFound("Apartment not found");

            var result = _service.UpdateApartment(id, updatedAparment);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return NoContent();  
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);

            return NoContent();
        }

    }
}
