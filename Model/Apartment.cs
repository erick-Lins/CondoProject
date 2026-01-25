namespace CondoProj.Model
{
    public class Apartment
    {
        public int Id { get; set; }
        public Tower IdTower { get; set; }
        public int AptNumber { get; set; }
        public int Floor { get; set; }
        public double Size { get; set; }

    }
}
