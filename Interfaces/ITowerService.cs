using CondoProj.Model;
using CondoProj.Utils;

namespace CondoProj.Interfaces
{
    public interface ITowerService
    {
        Result Create(Tower tower);
        Result UpdateTower(int id, Tower newTower);
        Result Delete(int id);
        List<Tower> GetAll();
        Tower GetById(int id);

    }
}
