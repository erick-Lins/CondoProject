using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CondoProj.Models
{
    public class Apartment
    {
        [JsonIgnore]
        public int ApartmentId { get; set; }
        [Required]
        [Range(1, 6, ErrorMessage = "Apt numbers can only be between 1 and 6")]
        public int AptNumber { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        [Range(20, 93.5, ErrorMessage = "Size of the apartment must be between 20m² and 93.5m²")]
        public double Size { get; set; }
        //FK Property 
        public int TowerId { get; set; }
        //NavigationProperty
        [JsonIgnore]
        public Tower? Tower{ get; set; }
    }
}
