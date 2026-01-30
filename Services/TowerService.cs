using CondoProj.Model;
using CondoProj.Utils;

namespace CondoProj.Services
{
    public class TowerService
    {
        Helper helper = new();

        public Result ValidateInfoTower(Tower tower, List<Tower> towerList)
        {
            //logic to establish perimeter based on size of the apartment

            bool hasTowNumber = CheckTowerNumber(tower, towerList);
            if (hasTowNumber)
                return Result.Fail("The tower number must be unique");

            return Result.Ok();
        }

        public bool CheckTowerNumber(Tower tower, List<Tower> towerList)
        {
            return towerList.Exists(x => x.TowNumber == tower.TowNumber);
        }
    }
}