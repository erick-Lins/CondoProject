using System.Diagnostics;
using CondoProj.Model;
using CondoProj.Interfaces;
using CondoProj.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient.DataClassification;

namespace CondoProj.Services
{
    public class TowerService : ITowerService
    {
        public static readonly List<Tower> towerList = new List<Tower>
        {
            new Tower { Id = 1, TowNumber = 1, Floors = 15, HasElevator = true, HasRooftop = false, Perimeter = 100 },
            new Tower { Id = 2, TowNumber = 2, Floors = 20, HasElevator = false, HasRooftop = true, Perimeter = 500 },
        };

        public Result Create(Tower tower)
        {
            //logic to establish perimeter based on size of the apartment

            bool hasTowNumber = CheckTowerNumber(tower, towerList);
            if (hasTowNumber)
                return Result.Fail("The tower number must be unique");

            tower.Id = towerList.Max(x => x.Id) + 1;
            towerList.Add(tower);

            return Result.Ok();
        }

        public Result UpdateTower(int id, Tower newTower)
        {
            if (towerList.Any(x => x.Id == id) == false)
                return Result.Fail("Tower not found");

            bool hasTowNumber = CheckTowerNumber(newTower, towerList);

            if (hasTowNumber)
                return Result.Fail("The tower number must be unique");

            Tower towerToUpdate = towerList.FirstOrDefault(x => x.Id == id);

            towerToUpdate.Perimeter = newTower.Perimeter;
            towerToUpdate.TowNumber = newTower.TowNumber;
            towerToUpdate.HasRooftop = newTower.HasRooftop;
            towerToUpdate.HasElevator = newTower.HasElevator;
            towerToUpdate.Floors = newTower.Floors;

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            bool existsId = towerList.Exists(x => x.Id == id);

            if (!existsId)
                return Result.Fail($"ID: {id} is invalid");

            Tower towerDelete = towerList.FirstOrDefault(x => x.Id == id);

            towerList.Remove(towerDelete);

            return Result.Ok();
        }

        public List<Tower> GetAll()
        {
            return towerList;
        }

        public Tower GetById(int id)
        {
            var tower = towerList.FirstOrDefault(x => x.Id == id);

            if (tower == null)
                return null;

            return tower;
        }
        public bool CheckTowerNumber(Tower tower, List<Tower> towerList)
        {
            return towerList.Exists(x => x.TowNumber == tower.TowNumber && x.Id != tower.Id);
        }
    }
}