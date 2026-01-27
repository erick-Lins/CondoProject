using CondoProj.Model;
using CondoProj.Utils;

namespace CondoProj.Services
{
    public class TowerService
    {
        Helper helper = new();

        public Result ValidateInfoTower(Tower tower)
        {
            
            if(tower.Floors > 20)
            {
                Result.Fail("Towers cannot have more than 20 floors.");
            }
            


            return Result.Ok();
        }



    }
}