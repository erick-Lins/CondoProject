using CondoProj.Model;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CondoProj.Utils;
using CondoProj.Services;

namespace CondoProj.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class OwnerController : ControllerBase
    {
        Utils.Helper utils = new();
        OwnerService service = new();

        private static readonly List<Owner> OwnerList = new List<Owner>
        {
            new Owner { Id = 1, Birthdate = new DateOnly(1997, 10, 12), FullName = "Rodrigo Ximenes", Pronoun = "He" },
            new Owner { Id = 2, Birthdate = new DateOnly(2021, 04, 12), FullName = "Crianço pequeno", Pronoun = "He" }
        };

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(OwnerList);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            bool existsId = OwnerList.Exists(x => x.Id == id);

            if (utils.ValidateId(id, existsId) == false)
                return BadRequest($"ID: {id} is invalid");

            Owner owner = OwnerList.FirstOrDefault(x => x.Id == id);

            return Ok(owner);
        }

        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            var result = service.ValidateInfoOwner(owner);

            if (!(result.Success))
            {
                return BadRequest(result.ErrorMessage);
            }

            owner.Id = OwnerList.Max(x => x.Id) + 1;
            OwnerList.Add(owner);

            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Owner updatedOwner)
        {
            bool isValidId = OwnerList.Exists(x => x.Id == id);

            if (utils.ValidateId(id, isValidId) == false)
                return BadRequest($"ID: {id} is invalid");

            Owner owner = OwnerList.FirstOrDefault(x => x.Id == id);

            if (owner == null)
                return NotFound("Owner not found");

            var result = service.ValidateInfoOwner(updatedOwner);

            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            
            owner.FullName = updatedOwner.FullName;
            owner.Birthdate = updatedOwner.Birthdate;
            owner.Pronoun = updatedOwner.Pronoun;

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            bool isValidId = OwnerList.Exists(x => x.Id == id);

            if (utils.ValidateId(id, isValidId) == false)
                return BadRequest($"ID: {id} is invalid");

            Owner owner = OwnerList.FirstOrDefault(x => x.Id == id);

            if (owner == null)
                return NotFound("Owner not found");

            OwnerList.Remove(owner);

            return Ok($"Owner {owner.FullName} deleted successfully");
        }
    }
}
