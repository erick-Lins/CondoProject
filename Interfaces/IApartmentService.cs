using CondoProj.Model;
using CondoProj.Utils;

namespace CondoProj.Interfaces
{
    public interface IApartmentService
    {
        Result Create(Apartment apartment);
        Result Update(int id, Apartment newApartment);
        Result Delete(int id);
        List<Apartment> GetAll();
        Apartment GetById(int id);
    }
}
