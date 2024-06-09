namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string input = string.Empty;

            List<Tire[]> tires = new();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] currentTires = new Tire[4]
                {
                    new Tire(int.Parse(tireInfo[0]), double.Parse(tireInfo[1])),
                    new Tire(int.Parse(tireInfo[2]), double.Parse(tireInfo[3])),
                    new Tire(int.Parse(tireInfo[4]), double.Parse(tireInfo[5])),
                    new Tire(int.Parse(tireInfo[6]), double.Parse(tireInfo[7]))
                };
                tires.Add(currentTires);
            }

            List<Engine> engine = new();

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] tireInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine currentEngine = new Engine(int.Parse(tireInfo[0]), double.Parse(tireInfo[1]));
                engine.Add(currentEngine);
            }

            List<Car> cars = new();
            while (((input = Console.ReadLine())) != "Show special")
            {
                string[] carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine currentEngine = engine[int.Parse(carInfo[5])];
                Tire[] currentTires = tires[int.Parse(carInfo[6])];
                Car currentCar = new(carInfo[0], carInfo[1], int.Parse(carInfo[2]), double.Parse(carInfo[3]), double.Parse(carInfo[4]), currentEngine, currentTires);
                cars.Add(currentCar);
            }

            List<Car> output = cars
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Sum(x => x.Pressure) > 9)
                .Where(x => x.Tires.Sum(x => x.Pressure) < 10)
                .ToList();


            foreach (Car car in output)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }

        }
    }
}
