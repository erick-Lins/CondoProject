using System.Text.Json.Serialization;

namespace CondoProj.Model
{
    public class Apartment
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Tower IdTower { get; set; }
        public int AptNumber { get; set; }
        public int Floor { get; set; }
        public double Size { get; set; }

    }
}
