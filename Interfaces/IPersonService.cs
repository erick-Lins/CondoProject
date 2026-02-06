using CondoProj.Model;
using CondoProj.Utils;

namespace CondoProj.Interfaces
{
    public interface IPersonService
    {
        Result Create(Person resident);
        Result UpdateResident(int id, Person newResident);
        Result Delete(int id);
        List<Person> GetAll();
        Person GetById(int id);
    }
}
