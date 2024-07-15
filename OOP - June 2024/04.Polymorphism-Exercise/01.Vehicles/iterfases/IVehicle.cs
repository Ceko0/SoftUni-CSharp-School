namespace Vehicles.iterfases
{
    public interface IVehicle
    {
        public double Fuel { get; }
        public double Consumpion { get; }
        public double TankCapacity { get; set; }

        public abstract string Drive(double distance);
        
        public abstract void Refuel(double fuel);
    }
}
