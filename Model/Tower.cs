using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CondoProj.Model
{
    public class Tower
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Number of the tower is required.")]
        //[RegularExpression("(\\d*\\.?\\d+)", ErrorMessage = "Tower Number must be an intenger.")]
        public int TowNumber { get; set; }

        [Required(ErrorMessage = "The number of floors is required.")]
        [RegularExpression("(\\d*\\.?\\d+)", ErrorMessage = "Floor Numbers must be an intenger.")]
        [Range(1,20, ErrorMessage = "Floor number must be between 1 and 20.")]
        public int Floors { get; set; }

        [AllowedValues("true", "false", ErrorMessage = "Values accepeted are either true or false.")]
        public bool HasRooftop { get; set; }

        [AllowedValues("true", "false", ErrorMessage = "Values accepeted are either true or false.")]
        public bool HasElevator { get; set; }

        [Required(ErrorMessage = "Perimeter of the tower is required. (in meters)")]
        [RegularExpression("(\\d*\\.?\\d+)", ErrorMessage = "Perimeter Value must be a double."), Range(100, 700)]
        public double Perimeter { get; set; }
    }
}
