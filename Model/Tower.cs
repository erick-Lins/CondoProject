namespace CondoProj.Model
{
    public class Tower
    {
        public int Id { get; set; }
        public int TowNumber { get; set; }
        public int Floors { get; set; }
        public bool HasRooftop { get; set; }
        public bool HasElevator { get; set; }
        public double Perimeter { get; set; }
    }
}
