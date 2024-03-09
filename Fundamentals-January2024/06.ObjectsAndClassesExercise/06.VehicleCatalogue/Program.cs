namespace _06.VehicleCatalogue
{
    class VehicleCatalog
    {
        public VehicleCatalog(string type, string model, string color, string horsePower)
        {
            Type = type.Substring(0, 1).ToUpper() + type.Substring(1);
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string HorsePower { get; set; }

        public override string ToString()
        {
            return $"Type: {Type}\n" +
        $"Model: {Model}\n" +
        $"Color: {Color}\n" +
        $"Horsepower: {HorsePower}";

            ;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<VehicleCatalog> VehicleList = new List<VehicleCatalog>();

            string income = "";
            while ((income = Console.ReadLine()) != "End")
            {
                string[] incomeVehicle = income
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                VehicleCatalog currentCatalog = new VehicleCatalog(incomeVehicle[0], incomeVehicle[1], incomeVehicle[2], incomeVehicle[3]);
                VehicleList.Add(currentCatalog);
            }

            income = "";
            while ((income = Console.ReadLine()) != "Close the Catalogue")
            {
                string vehickeToPrint = income;

                foreach (VehicleCatalog vehicle in VehicleList)
                {
                    if (vehicle.Model == vehickeToPrint)
                    {
                        Console.WriteLine(vehicle);
                        break;
                    }
                }
            }
            double carSum = 0.0;
            int carCounter = 0;
            double truckSum = 0.0;
            int truckCounter = 0;
            foreach (VehicleCatalog vehicle in VehicleList)
            {
                if (vehicle.Type == "Car")
                {
                    carSum += int.Parse(vehicle.HorsePower);
                    carCounter++;
                }
                else
                {
                    truckSum += int.Parse(vehicle.HorsePower);
                    truckCounter++;
                }
            }
           
            if (VehicleList.Any(x => x.Type == "Car")) Console.WriteLine($"Cars have average horsepower of: {carSum / carCounter:f2}.");
            else Console.WriteLine($"Cars have average horsepower of: 0.00.");
            if (VehicleList.Any(x => x.Type == "Truck")) Console.WriteLine($"Trucks have average horsepower of: {truckSum / truckCounter:f2}.");
            else Console.WriteLine($"Trucks have average horsepower of: 0.00."); 
            
        }
    }
}
