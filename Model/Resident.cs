using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace CondoProj.Model
{
    public class Resident
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }
        [JsonIgnore]
        public Owner IdOwner { get; set; }
        public Apartment IdApartment { get; set; }
        public bool IsOwner { get; set; }
    }
}
