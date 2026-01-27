using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CondoProj.Model
{
    public class Tower
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "The number of the tower is required.")]
        public int TowNumber { get; set; }
        [Required(ErrorMessage = "The number of floors is required.")]
        public int Floors { get; set; }
        [Required(ErrorMessage = "Input Yes or No if either the tower has a rooftop.")]
        public bool HasRooftop { get; set; }
        [Required(ErrorMessage = "Input Yes or No if either the tower has a elevator.")]
        public bool HasElevator { get; set; }
        [Required(ErrorMessage = "Perimeter of the tower is required. (in meters)")]
        public double Perimeter { get; set; }
    }
}
