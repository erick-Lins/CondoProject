using System.Text.Json.Serialization;

namespace CondoProj.Model
{
    public class Apartment
    {
        [JsonIgnore]
        public int ApartmentId { get; set; }
        public int AptNumber { get; set; }
        public int Floor { get; set; }
        public double Size { get; set; }
        
        //FK Property
        public int TowerId { get; set; }
        //NavigationProperty
        public Tower Tower{ get; set; }

        //Fk Property
        public int PersonId { get; set; }
        // Navigation Property
        public Person Person { get; set; }

    }
}
