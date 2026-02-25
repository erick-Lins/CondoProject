using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set => _fullName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value?.ToLower());
        }

        private string _pronoun;
        [Required(ErrorMessage = "Pronoun is required")]
        [AllowedValues("He", "She","They", ErrorMessage = "Values must be He, She or They")]
        public string Pronoun
        {
            get => _pronoun;
            set => _pronoun = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value?.ToLower());
        }

        [Required(ErrorMessage = "Birthdate is required")]
        [DataType(DataType.Date), CustomDateValidation]
        public DateTime Birthdate { get; set; }

        private string _type;
        [Required(ErrorMessage = "Type is required.")]
        [AllowedValues("Owner", "Resident", ErrorMessage = "Values must be Owner or Resident")]
        public string Type
        {
            get => _type;
            set => _type = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value?.ToLower());
        }
        //Navigation Property
        [JsonIgnore]
        public Apartment? Apartment { get; set; }
        //FK Property
        public int ApartmentId { get; set; }
    }
}
