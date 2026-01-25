using CondoProj.Model;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace CondoProj.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class OwnerController : ControllerBase
    {
        private static readonly List<Owner> OwnerList = new List<Owner>
        {
            new Owner {  Id = 1, BirthDate = new DateOnly(1997,10,12), FullName = "Rodrigo Ximenes", Pronoun = "He"  },
            new Owner {  Id = 2, BirthDate = new DateOnly(2021, 04,12), FullName = "Crianço pequeno", Pronoun = "He"  }
        };

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(OwnerList);
        }


        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            if (id <= 0 || id == null)
                return BadRequest("ID inválido");

            Owner owner = null;

            foreach (var item in OwnerList)
            {
                if (id == item.Id)
                {
                    owner = item;
                    break;
                }
            }

            return Ok(owner);
        }

        [HttpPost]
        public JsonResult Create(Owner owner)
        {
            owner.Id = OwnerList.Max(x => x.Id) + 1;
            OwnerList.Add(owner);

            return new JsonResult($"{owner.FullName} registered successfully");
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Owner updatedOwner)
        {
            if (id <= 0)
                return BadRequest("ID inválido");

            Owner owner = OwnerList.FirstOrDefault(x => x.Id == id);

            if (owner == null)
                return NotFound("Owner não encontrado");

            owner.FullName = updatedOwner.FullName;
            owner.BirthDate = updatedOwner.BirthDate;
            owner.Pronoun = updatedOwner.Pronoun;

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {

            if (id <= 0)
                return BadRequest("ID inválido");

            Owner owner = null;

            foreach(var item in OwnerList)
            {
                if (owner.Id == item.Id)
                {
                    owner = item;
                    break;
                }
            }

            if (owner == null)
                return NotFound("Owner não encontrado");

            OwnerList.Remove(owner);

            return Ok(OwnerList);
        }
    }
}
