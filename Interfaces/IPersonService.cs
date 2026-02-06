using CondoProj.Model;
using CondoProj.Utils;

namespace CondoProj.Interfaces
{
    public interface IPersonService
    {
        Result Create(Person person);
        Result UpdatePerson(int id, Person newPerson);
        Result Delete(int id);
        List<Person> GetAll();
        Person GetById(int id);
    }
}
