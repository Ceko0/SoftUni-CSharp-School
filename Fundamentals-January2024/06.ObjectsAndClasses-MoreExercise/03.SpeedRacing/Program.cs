namespace _03.SpeedRacing
{
   
    internal class Program
    {
        class Car
        {
            public Car(string model, double fuelAmount, double fuelConsumption, double distance)
            {
                Model = model;
                FuelAmount = fuelAmount;
                FuelConsumption = fuelConsumption;
                Distance = distance;
            }

            public string Model { get; set; }
            public double FuelAmount { get; set; }
            public double FuelConsumption { get; set; }
            public double Distance { get; set; }
            public double TraveledDistance { get; set; } = 0;

            public static void DistanceCalculator(Car currentCar, double distanceToMove)
            {
                double distance = currentCar.FuelAmount / currentCar.FuelConsumption;
                if (distance < distanceToMove)
                {
                    Console.WriteLine($"Insufficient fuel for the drive");
                }
                else
                {
                    currentCar.FuelAmount -= distanceToMove * currentCar.FuelConsumption;
                    currentCar.TraveledDistance += distanceToMove;
                }
            }

            public override string ToString()
            {
                return $"{Model} {FuelAmount:f2} {TraveledDistance}";
            }
        }
        static void Main(string[] args)
        {
            int carTracker = int.Parse(Console.ReadLine());
            List<Car> carsList = new List<Car>();
            for (int i = 0; i < carTracker; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split()
                    .ToArray();
                carsList.Add(new Car(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]), 0));
            }

            string income = "";
            while ((income = Console.ReadLine()) != "End")
            {
                string[] carInfo = income
                    .Split()
                    .ToArray();
                string model = carInfo[1];
                double distance = double.Parse(carInfo[2]);
                Car currentcar = carsList.FirstOrDefault(x => x.Model == carInfo[1]);
                Car.DistanceCalculator(currentcar, Double.Parse(carInfo[2]));

            }

            foreach (var car in carsList)
            {
                Console.WriteLine(car);                
            }
        }
    }
}
