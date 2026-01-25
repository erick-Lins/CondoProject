using CondoProj.Model;
using CondoProj.Helper;

namespace CondoProj.Services
{
    public class OwnerService
    {

        public Result CreateOwner(Owner owner)
        {

            DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now);
            int age = dateOnly.Year - owner.Birthdate.Year;

            if (owner.Birthdate >= dateOnly)
            {
                return Result.Fail("Date cannot be greater than today's");
            }
            else if (age < 18)
            {
                return Result.Fail("You must be of legal age to own an apartment (18 years)");
            }

            //salvar no banco de dados quando criado o repository

            return Result.Ok();

        }




    }
}
