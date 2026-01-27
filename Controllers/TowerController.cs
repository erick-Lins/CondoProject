using System.Diagnostics;
using CondoProj.Model;
using CondoProj.Services;
using CondoProj.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CondoProj.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TowerController : ControllerBase
    {
        Helper helper = new();
        TowerService service = new();

        private static readonly List<Tower> towerList = new List<Tower>
        {
            new Tower { Id = 1, TowNumber = 1, Floors = 15, HasElevator = true, HasRooftop = false, Perimeter = 100  },
            new Tower { Id = 2, TowNumber = 2, Floors = 15, HasElevator = false, HasRooftop = true, Perimeter = 67.3  }
        };

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(towerList);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            bool existsId = towerList.Exists(x => x.Id == id);
            if(helper.ValidateId(id, existsId) == false)
            {
                return BadRequest($"ID: {id} is invalid");
            }

            Tower tower = towerList.FirstOrDefault(x => x.Id == id);

            return Ok(tower);
        }

        [HttpPost]
        public IActionResult Create(Tower tower)
        {
            service.ValidateInfoTower();

            tower.Id = towerList.Max(x => x.Id) + 1;
            towerList.Add(tower);

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Tower updatedTower, int id)
        {
            Tower towerToUpdate = towerList.FirstOrDefault(x => x.Id == id);

            towerToUpdate.Perimeter = updatedTower.Perimeter;
            towerToUpdate.TowNumber = updatedTower.TowNumber;
            towerToUpdate.HasRooftop = updatedTower.HasRooftop;
            towerToUpdate.HasElevator = updatedTower.HasElevator;
            towerToUpdate.Floors = updatedTower.Floors;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool existsId = towerList.Exists(x => x.Id == id);
            if (helper.ValidateId(id, existsId) == false)
            {
                return BadRequest($"ID: {id} is invalid");
            }

            Tower towerToDelete = towerList.FirstOrDefault(x => x.Id == id);

            if (towerToDelete == null)
            {
                return BadRequest("Tower not found");
            }

            towerList.Remove(towerToDelete);
            return NoContent();
        }


    }
}
