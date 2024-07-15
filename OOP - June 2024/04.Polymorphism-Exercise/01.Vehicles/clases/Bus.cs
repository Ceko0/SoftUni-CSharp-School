namespace Vehicles.clases
{
    public class Bus : Vehicle
    {
        public bool IsEmpty { get; set; }
        public Bus(double fuel, double consumpion , double tankCapacity) 
            : base(fuel, consumpion, tankCapacity)
        {
        }
        public override double Consumpion => base.Consumpion + (IsEmpty ? 0 : 1.4);

        
    }
}
