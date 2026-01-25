using System.Text.Json.Serialization;

namespace CondoProj.Model
{
    public class Owner
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Pronoun { get; set; }
    }
}
