namespace _07.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new();

            int carCounter = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCounter; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car currentCar = new(carInfo[0], int.Parse(carInfo[1]), int.Parse(carInfo[2]), int.Parse(carInfo[3]), carInfo[4], double.Parse(carInfo[5]), int.Parse(carInfo[6]), double.Parse(carInfo[7]), int.Parse(carInfo[8]), double.Parse(carInfo[9]), int.Parse(carInfo[10]), double.Parse(carInfo[11]), int.Parse(carInfo[12]));

                cars.Add(currentCar);

            }
            string outputWord = Console.ReadLine();
            if (outputWord == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.Where(x => x.Cargo.Type == "fragile").Where(x => x.Tires.Any(x => x.Pressure < 1))));
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.Where(x => x.Cargo.Type == "flammable").Where(x => x.Engine.Power > 250)));
            }
        }
    }
}
