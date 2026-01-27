using CondoProj.Model;
using CondoProj.Utils;
using System.Text.RegularExpressions;

namespace CondoProj.Services
{
    public class OwnerService
    {

        public Result ValidateInfoOwner(Owner owner)
        {
            Helper helper = new Helper();

            DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now);
            int age = dateOnly.Year - owner.Birthdate.Year;
            bool isNumeric = helper.IsNumeric(owner.FullName);

            if (isNumeric)
            {
                return Result.Fail("Name cannot be numeric");
            }

            if (!(helper.ValidatePronoun(owner.Pronoun)))
            {
                return Result.Fail("Pronouns can only be: She (ela), He (ele) or They (elu)");
            }


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
