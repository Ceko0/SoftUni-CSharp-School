namespace _06.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carCounter = int.Parse(Console.ReadLine());

            List<Car> cars = new();

            for (int i = 0; i < carCounter; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Car currentCar = new();
                currentCar.Model = carInfo[0];
                currentCar.FuelAmount = double.Parse(carInfo[1]);
                currentCar.FuelConsumptionPerKilometer = double.Parse(carInfo[2]);
                cars.Add(currentCar);
            }
            string input = string.Empty;
            while((input = Console.ReadLine()) != "End")
            {
                string[] driveInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car currentCar = cars.FirstOrDefault(car => car.Model == driveInfo[1]);
                
                currentCar.drive(double.Parse(driveInfo[2]));               
            }
            cars.ForEach(car => Console.WriteLine(car));
        }
    }
}
