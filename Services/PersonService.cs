using CondoProj.Interfaces;
using CondoProj.Model;
using CondoProj.Utils;

namespace CondoProj.Services
{
    public class PersonService : IPersonService
    {

        private readonly CondoDbContext _dbContext;

        public PersonService(CondoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Result Create(Person person)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            var list = _dbContext.Persons.ToList();
            return list;
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Result UpdatePerson(int id, Person newPerson)
        {
            throw new NotImplementedException();
        }
    }
}
