using System.Reflection.Metadata.Ecma335;

namespace CondoProj.Model
{
    public class Resident
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Owner IdOwner { get; set; }
        public Apartment IdApartment { get; set; }
        public bool IsOwner { get; set; }
    }
}
