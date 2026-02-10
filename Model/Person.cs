using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using CondoProj.DataAnnotation;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace CondoProj.Model
{
    public class Person
    {
        [JsonIgnore]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        //[RegularExpression("^(?=.*?[A-Za-z])[A-Za-z+]+$", ErrorMessage = "Name must only have letters.")]
        public string FullName { get; set; }

        private string _pronoun;
        [Required(ErrorMessage = "Pronoun is required")]
        [AllowedValues("he", "she","they", ErrorMessage = "Values must be He, She or They")]
        //[RegularExpression("^(?=.*?[A-Za-z])[A-Za-z+]+$", ErrorMessage = "Pronoun must only have leters")]
        public string Pronoun
        {
            get => _pronoun;
            set => _pronoun = value?.ToLowerInvariant();
        }

        [Required(ErrorMessage = "Birthdate is required")]
        [DataType(DataType.Date), CustomDateValidation]
        public DateTime Birthdate { get; set; }

        private string _type;
        [Required(ErrorMessage = "Type is required.")]
        [AllowedValues("owner", "resident", ErrorMessage = "Values must be Owner or Resident")]
        public string Type
        {
            get => _type;
            set => _type.ToLowerInvariant();
        }
        //Navigation Property
        [JsonIgnore]
        public Apartment? Apartment { get; set; }
        //FK Property
        public int ApartmentId { get; set; }
    }
}
