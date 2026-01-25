using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CondoProj.Model
{
    public class Owner
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Birthdate is required")]
        public DateOnly Birthdate { get; set; }
        [Required(ErrorMessage = "Pronoun is required")]
        public string Pronoun { get; set; }
    }
}
