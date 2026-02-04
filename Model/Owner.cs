using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CondoProj.Model
{
    public class Owner
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^(?=.*?[A-Za-z])[A-Za-z+]+$", ErrorMessage = "Name must only have letters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Birthdate is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly Birthdate { get; set; }

        [Required(ErrorMessage = "Pronoun is required")]
        [AllowedValues("He","he", "She", "she", "They", "they", ErrorMessage = "Values must be He, She or They")]
        [RegularExpression("^(?=.*?[A-Za-z])[A-Za-z+]+$", ErrorMessage = "Pronoun must only have leters")]
        public string Pronoun { get; set; }
    }
}
