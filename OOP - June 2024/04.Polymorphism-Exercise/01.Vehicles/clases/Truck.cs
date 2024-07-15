namespace Vehicles.clases
{
    public class Truck : Vehicle
    {
        public Truck(double fuel, double consumpion, double tankCapacity) 
            : base(fuel, consumpion, tankCapacity)
        {
        }
        public override double Consumpion => base.Consumpion + 1.6;

        public override void Refuel(double fuel)
        {
            if (this.Fuel + fuel > TankCapacity)
            {
                base.Refuel(fuel);
                return;
            }
            base.Refuel(fuel*0.95);
        }
    }
}
