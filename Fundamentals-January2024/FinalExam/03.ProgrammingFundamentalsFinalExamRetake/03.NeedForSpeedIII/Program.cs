namespace _03.NeedForSpeedIII
{
    internal class Program
    {
        class Cars
        {
            public Cars(string name, int kilometers, int fuel)
            {
                Name = name;
                Kilometers = kilometers;
                Fuel = fuel;
            }

            public string Name { get; set; }
            public int Kilometers { get; set; }
            public int Fuel { get; set; }
            public override string ToString()
            {
                return $"{Name} -> Mileage: {Kilometers} kms, Fuel in the tank: {Fuel} lt.";
            }
        }
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Cars> carsList = new List<Cars>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Cars car = new Cars(carInfo[0], int.Parse(carInfo[1]), int.Parse(carInfo[2]));
                carsList.Add(car);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commands = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string commend = commands[0];
                string car = commands[1];
                Cars currentCar = carsList.FirstOrDefault(x => x.Name == car);
                if (currentCar != null)
                {
                    switch (commend)
                    {

                        case "Drive":
                            int distance = int.Parse(commands[2]);
                            int fuel = int.Parse(commands[3]);
                            if (currentCar.Fuel < fuel)
                            {
                                Console.WriteLine("Not enough fuel to make that ride");
                            }
                            else
                            {
                                currentCar.Kilometers += distance;
                                currentCar.Fuel -= fuel;
                                Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                            }
                            if (currentCar.Kilometers >= 100_000)
                            {
                                Console.WriteLine($"Time to sell the {currentCar.Name}!");
                                carsList.Remove(currentCar);
                            }
                            break;
                        case "Refuel":
                            fuel = int.Parse(commands[2]);
                            if (currentCar.Fuel + fuel <= 75)
                            {
                                Console.WriteLine($"{currentCar.Name} refueled with {fuel} liters");
                                currentCar.Fuel += fuel;
                            }
                            else
                            {
                                Console.WriteLine($"{currentCar.Name} refueled with {75 - currentCar.Fuel} liters");
                                currentCar.Fuel = 75;
                            }

                            break;
                        case "Revert":
                            int kilometers = int.Parse(commands[2]);
                            currentCar.Kilometers -= kilometers;
                            if (currentCar.Kilometers < 10_000)
                            {
                                currentCar.Kilometers = 10000;
                            }
                            else
                            {
                                Console.WriteLine($"{currentCar.Name} mileage decreased by {kilometers} kilometers");
                            }
                            break;
                    }
                }

            }
            Console.WriteLine(string.Join("\n", carsList));
        }
    }
}
