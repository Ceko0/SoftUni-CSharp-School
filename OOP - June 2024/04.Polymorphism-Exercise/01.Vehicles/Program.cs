using Vehicles.clases;
using Vehicles.iterfases;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            double carFuel = double.Parse(carInfo[1]);
            double carConsumpion = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);
            Car car = new Car(FuelCheck(carFuel, carTankCapacity), carConsumpion, carTankCapacity);
            string[] truckInfo = Console.ReadLine().Split();
            double truckFuel = double.Parse(truckInfo[1]);
            double truckConsumpion = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);
            Truck truck = new Truck(FuelCheck(truckFuel, truckTankCapacity), truckConsumpion, truckTankCapacity);
            string[] busInfo = Console.ReadLine().Split();
            double busFuel = double.Parse(busInfo[1]);
            double busConsumpion = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            Bus bus = new Bus(FuelCheck(busFuel, busTankCapacity), busConsumpion, busTankCapacity);

            int driveCounter = int.Parse(Console.ReadLine());
            for (int i = 0; i < driveCounter; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                string vehicleType = input[1];
                var vehicle = GetVehicle(vehicleType, car, truck, bus);

                if (command == "Drive")
                {
                    double distance = double.Parse(input[2]);
                    Console.WriteLine(vehicle.Drive(distance));

                }
                else if (command == "Refuel")
                {
                    double liters = double.Parse(input[2]);
                    vehicle.Refuel(liters);
                }
                else if (command == "DriveEmpty")
                {
                    double distance = double.Parse(input[2]);
                    bus.IsEmpty = true;
                    Console.WriteLine(vehicle.Drive(distance));
                    bus.IsEmpty = false;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static double FuelCheck(double fuel, double tankCapacity)
        {
            if (fuel > tankCapacity)
            {
                return 0.0;
            }
            return fuel;
        }

        private static IVehicle GetVehicle(string vehicleType, IVehicle car, IVehicle truck, IVehicle bus)
        => vehicleType switch
        {
            "Car" => car,
            "Truck" => truck,
            "Bus" => bus,
            _ => throw new InvalidOperationException("Invalid vehicle type")
        };
    }
}
