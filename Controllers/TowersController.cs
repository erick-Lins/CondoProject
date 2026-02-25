using System.Diagnostics;
using CondoProj.Model;
using CondoProj.Services;
using CondoProj.Interfaces;
using CondoProj.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CondoProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TowersController : ControllerBase
    {
        private readonly ITowerService _service;

        public TowersController(ITowerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _service.GetAll();

            if (result == null || !result.Any())
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (result == null)
                return NotFound($"Tower of id: {id} was not found.");

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Tower tower)
        {

            if(tower == null)
                return BadRequest("Body request shouldn't be null.");

            var result = _service.Create(tower);

            if (!result.Success || !ModelState.IsValid)
                return BadRequest(result.ErrorMessage);

            return CreatedAtAction(nameof(GetById), new { id = tower.TowerId}, tower);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Tower updatedTower, int id)
        {
            if (updatedTower == null)
                return NotFound($"ID: {id} is invalid");

            var result = _service.UpdateTower(id, updatedTower);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return NoContent();
        }


    }
}
