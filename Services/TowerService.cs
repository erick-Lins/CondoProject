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
        private readonly CondoDbContext _dbContext;
        public TowerService(CondoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Result Create(Tower tower)
        {

            bool hasTowNumber = _dbContext.Towers.Any(x => x.TowNumber == tower.TowNumber);

            if (hasTowNumber)
                return Result.Fail("The tower number must be unique");

            //logic to establish perimeter based on size of the apartment

            _dbContext.Towers.Add(tower);
            _dbContext.SaveChangesAsync();

            return Result.Ok();
        }

        public Result UpdateTower(int id, Tower newTower)
        {
            Tower towerToUpdate = _dbContext.Towers.FirstOrDefault(x => x.TowerId == id);

            if (towerToUpdate == null)
                return Result.Fail($"The id: {id} was not found.");

            bool numberInUse = _dbContext.Towers.Any(x => x.TowNumber == newTower.TowNumber && x.TowerId != id);

            if (numberInUse)
                return Result.Fail($"The tower number: {newTower.TowNumber} already exists.");

            towerToUpdate.Perimeter = newTower.Perimeter;
            towerToUpdate.TowNumber = newTower.TowNumber;
            towerToUpdate.HasRooftop = newTower.HasRooftop;
            towerToUpdate.HasElevator = newTower.HasElevator;
            towerToUpdate.Floors = newTower.Floors;

            _dbContext.SaveChanges();

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            Tower towerToDelete = _dbContext.Towers.FirstOrDefault(x => x.TowerId == id);

            if (towerToDelete == null)
                return Result.Fail($"Tower of id: {id} was not found.");

            _dbContext.Towers.Remove(towerToDelete);
            _dbContext.SaveChanges();

            return Result.Ok();
        }

        public List<Tower> GetAll()
        {
            var result = _dbContext.Towers.ToList();
            return result;
        }

        public Tower GetById(int id)
        {
            var tower = _dbContext.Towers.FirstOrDefault(x => x.TowerId == id);

            if (tower == null)
                return null;

            return tower;
        }

        public int GetTowerFloors(int towerId)
        {
            var tower = _dbContext.Towers.FirstOrDefault(x => x.TowerId == towerId);

            return tower.Floors;

        }
    }
}