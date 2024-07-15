namespace Vehicles.clases
{
    public class Car : Vehicle
    {
        public Car(double fuel, double consumpion, double tankCapacity) 
            : base(fuel, consumpion, tankCapacity)
        {
        }
        public override double Consumpion => base.Consumpion + 0.9;
    }
}
