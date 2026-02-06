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
        public Result Create(Apartment apartment)
        {
            //bool existsApartment = apartmentList.Any(x => x.AptNumber == apartment.AptNumber 
            //                                           && x.IdTower == apartment.IdTower);
            //if (existsApartment)
            //    return Result.Fail($"Apartment already exists in: {apartment.AptNumber}, Tower: {apartment.IdTower}");

            //apartment.Id = apartmentList.Max(x => x.Id) + 1;
            //apartmentList.Add(apartment);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            //var apartmentToDelete = apartmentList.FirstOrDefault(x => x.Id == id);

            //if (apartmentToDelete == null)
            //    return Result.Fail("Id not found");

            //apartmentList.Remove(apartmentToDelete);

            return Result.Ok();
        }

        public List<Apartment> GetAll()
        {
            var listAp = new List<Apartment>();
            return listAp ;
        }

        public Apartment GetById(int id)
        {
            var apartment = new Apartment();

            if (apartment == null)
                return null;

            return apartment;
        }

        public Result UpdateApartment(int id, Apartment newApartment)
        {
            throw new NotImplementedException();
        }
    }
}
