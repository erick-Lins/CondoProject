using CondoProj.Model;

namespace CondoProj.Services
{
    public class OwnerService
    {

        public void CreateOwner(Owner owner)
        {

            DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now);
            int age = dateOnly.Year - owner.Birthdate.Year;

            if (owner.Birthdate >= dateOnly)
            {
                throw new Exception("Date must not be greater than today's");
            }
            else if (age < 18)
            {
                throw new Exception("You must be legal age to own an apartment (18 years)");
            }

            //salvar no banco de dados quando criado o repository
        }




    }
}
