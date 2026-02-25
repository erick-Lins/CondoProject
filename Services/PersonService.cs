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
            var existsPerson = _dbContext.Persons.Any(x => x.FullName == person.FullName && x.Birthdate == person.Birthdate);

            if (existsPerson)
                return Result.Fail("This person is already registered");

            if (IsLegalOfAge(person.Birthdate) == false && person.Type == "owner")
                return Result.Fail("To register as an owner, the person must be of legal age.");

            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            var personToDelete = _dbContext.Persons.FirstOrDefault(x => x.PersonId == id);

            if (personToDelete == null)
                return Result.Fail($"The Person of id: {id} was not found.");

            _dbContext.Persons.Remove(personToDelete);
            _dbContext.SaveChanges();

            return Result.Ok();
        }

        public List<Person> GetAll()
        {
            var list = _dbContext.Persons.ToList();
            return list;
        }

        public Person GetById(int id)
        {
            var person = _dbContext.Persons.FirstOrDefault(x => x.PersonId == id);

            if (person == null)
                return null;

            return person;

        }

        public Result UpdatePerson(int id, Person newPerson)
        {
            var personToUpdate = _dbContext.Persons.FirstOrDefault(x => x.PersonId == id);

            if (personToUpdate == null)
                return Result.Fail($"Person of id: {id} was not found.");

            bool alreadyExists = _dbContext.Persons.Any(x => x.FullName == newPerson.FullName && x.ApartmentId == newPerson.ApartmentId);

            if (alreadyExists)
                return Result.Fail($"Person already exists");

            personToUpdate.FullName = newPerson.FullName;
            personToUpdate.Birthdate = newPerson.Birthdate;
            personToUpdate.Pronoun = newPerson.Pronoun.ToLower();
            personToUpdate.Type = newPerson.Type;
            personToUpdate.ApartmentId = newPerson.ApartmentId;

            return Result.Ok();
        }

        public bool IsLegalOfAge(DateTime birthDate)
        {
            var age = DateTime.Now.Year - birthDate.Year;

            return age > 18 ? true : false;
        }
    }
}
