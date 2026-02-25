using CondoProj.Interfaces;
using CondoProj.Model;
using CondoProj.Utils;
using CondoProj.Services;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CondoProj.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly CondoDbContext _dbContext;
        private readonly ITowerService _towerService;
        public ApartmentService(CondoDbContext dbContext, ITowerService towerService)
        {
            _dbContext = dbContext;
            _towerService = towerService;
        }

        public Result Create(Apartment apartment)
        {
            bool existsApartment = _dbContext.Apartments.Any(x => x.AptNumber == apartment.AptNumber && x.Floor == apartment.Floor && x.TowerId == apartment.TowerId);

            if (existsApartment)
                return Result.Fail($"The apartment number: {apartment.AptNumber} is already in use.");

            bool existsTower = _dbContext.Towers.Any(x => x.TowerId == apartment.TowerId);

            if (!existsTower)
                return Result.Fail($"The tower of number {apartment.TowerId} was not found");

            if (apartment.Floor > _towerService.GetById(apartment.TowerId).Floors)
                return Result.Fail("The apartment floor number cannot be greater than the tower's");

            apartment.AptNumber = Convert.ToInt32(String.Concat(apartment.Floor, apartment.AptNumber)); 

            _dbContext.Apartments.Add(apartment);
            _dbContext.SaveChanges();

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            var apartmentToDelete = _dbContext.Apartments.FirstOrDefault(x => x.ApartmentId == id);

            if (apartmentToDelete == null)
                return Result.Fail($"Apartment of id: {id} was not found.");

            _dbContext.Apartments.Remove(apartmentToDelete);
            _dbContext.SaveChanges();

            return Result.Ok();
        }

        public List<Apartment> GetAll()
        {
            var apartmentList = _dbContext.Apartments.ToList();
            return apartmentList;
        }

        public Apartment GetById(int id)
        {
            var apartment = _dbContext.Apartments.FirstOrDefault(x => x.ApartmentId == id);

            if (apartment == null)
                return null;

            return apartment;
        }

        public Result UpdateApartment(int id, Apartment newApartment)
        {
            var apartmentToUpdate = _dbContext.Apartments.FirstOrDefault(x => x.ApartmentId == id);

            if (apartmentToUpdate == null)
                return Result.Fail($"Apartment of id: {id} was not found.");

            bool numberInUse = _dbContext.Apartments.Any(x => x.AptNumber == newApartment.AptNumber && x.ApartmentId != id);

            if (numberInUse)
                return Result.Fail($"Apartment number {newApartment.AptNumber} is already in use.");

            apartmentToUpdate.Size = newApartment.Size;
            apartmentToUpdate.Floor = newApartment.Floor;
            apartmentToUpdate.AptNumber = Convert.ToInt32(String.Concat(newApartment.Floor, newApartment.AptNumber));
            apartmentToUpdate.TowerId = newApartment.TowerId;

            _dbContext.SaveChanges();

            return Result.Ok();
        }
    }
}
