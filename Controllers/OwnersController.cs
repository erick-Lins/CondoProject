using CondoProj.Model;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CondoProj.Utils;
using CondoProj.Services;
using CondoProj.Interfaces;

namespace CondoProj.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _service;

        public OwnersController(IOwnerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _service.GetAll();

            if (!result.Any())
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var owner = _service.GetById(id);

            if (owner == null)
                return NotFound("Owner Not found");

            return Ok(owner);
        }

        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            var result = _service.Create(owner);
            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Owner updatedOwner)
        {
            if (updatedOwner == null)
                return NotFound($"ID: {id} is invalid");

            var result = _service.UpdateOwner(id, updatedOwner);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return NoContent();
        }
    }
}
