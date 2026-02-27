using CondoProj.Interfaces;
using CondoProj.Model;
using CondoProj.Utils;
using CondoProj.Services;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics;

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
            if (apartment.Floor < 0)
                return Result.Fail($"Floor cannot be negative. (There is no underground garage yet!!!)");

            apartment.AptNumber = Convert.ToInt32(String.Concat(apartment.Floor, apartment.AptNumber)); 

            var tower = _towerService.GetById(apartment.TowerId);
            if (tower == null)
                return Result.Fail($"Tower of number {apartment.TowerId} was not found");

            if (apartment.Floor > tower.Floors)
                return Result.Fail("Apartment floor number cannot be greater than the tower's");

            if (!IsSizeValid(apartment, tower))
                return Result.Fail($"Apartment size exceeds the 80% of floor threshold");

            bool exists = _dbContext.Apartments.Any(x => 
                x.AptNumber == apartment.AptNumber && 
                x.Floor == apartment.Floor && 
                x.TowerId == apartment.TowerId);

            if (exists)
                return Result.Fail($"Apartment number: {apartment.AptNumber} is already in use.");

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

        public bool IsSizeValid(Apartment apartment, Tower tower)
        {

            double towerSize = tower.Perimeter;

            double floorSum = _dbContext.Apartments
                                .Where(x => x.Floor == apartment.Floor)
                                .Sum(x => x.Size) + apartment.Size;

            double thresholdValue = (towerSize * 80) / 100;

            return floorSum > thresholdValue ? false : true;
        }
    }
}
