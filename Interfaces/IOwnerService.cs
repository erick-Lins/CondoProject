using CondoProj.Model;

using CondoProj.Utils;

namespace CondoProj.Interfaces
{
    public interface IOwnerService
    {
        Result Create(Owner owner);
        Result UpdateOwner(int id, Owner newOwner);
        Result Delete(int id);
        List<Owner> GetAll();
        Owner GetById(int id);

    }
}
