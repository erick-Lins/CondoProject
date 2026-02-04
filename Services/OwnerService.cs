using CondoProj.Interfaces;
using CondoProj.Model;
using CondoProj.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.RegularExpressions;

namespace CondoProj.Services
{
    public class OwnerService : IOwnerService
    {
        private static readonly List<Owner> ownerList = new List<Owner>
        {
            new Owner { Id = 1, Birthdate = new DateOnly(1997, 10, 12), FullName = "Rodrigo Ximenes", Pronoun = "He" },
            new Owner { Id = 2, Birthdate = new DateOnly(2021, 04, 12), FullName = "Crianço pequeno", Pronoun = "He" }
        };

        public Result Create(Owner owner)
        {
            bool hasOwner = ownerList.Any(x => x.FullName == owner.FullName
                                         && x.Birthdate == owner.Birthdate);
            if (hasOwner)
                return Result.Fail("Owners must be unique");

            owner.Id = ownerList.Max(x => x.Id) + 1;
            ownerList.Add(owner);
            return Result.Ok();
        }

        public Result UpdateOwner(int id, Owner newOwner)
        {
            if (!ownerList.Exists(x => x.Id == id))
                return Result.Fail("Owner not found to update.");

            Owner ownerToUpdate = ownerList.FirstOrDefault(x => x.Id == id);

            ownerToUpdate.FullName = newOwner.FullName;
            ownerToUpdate.Birthdate = newOwner.Birthdate;
            ownerToUpdate.Pronoun = newOwner.Pronoun;

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            bool existsId = ownerList.Exists(x => x.Id == id);

            if (!existsId)
                return Result.Fail("Id not found");

            var ownerToDelete = ownerList.FirstOrDefault(x => x.Id == id);
            ownerList.Remove(ownerToDelete);

            return Result.Ok();

        }


        public List<Owner> GetAll()
        {
            return ownerList;
        }

        public Owner GetById(int id)
        {
            var owner = ownerList.FirstOrDefault(x => x.Id == id);
            if (owner == null)
                return null;

            return owner;
        }

    }
}
