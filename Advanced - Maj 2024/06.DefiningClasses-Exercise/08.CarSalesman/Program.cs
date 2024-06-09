namespace _08.CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new();

            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                int displacement = 0;
                string efficiency = null;

                bool isNotDisplacement = true;

                if (engineInfo.Length >= 3)
                {
                    isNotDisplacement = int.TryParse(engineInfo[2] , out displacement);
                }
                if(engineInfo.Length == 3 && !isNotDisplacement)
                {
                    efficiency = engineInfo[2];
                }
                if (engineInfo.Length == 4)
                {
                    efficiency = engineInfo[3];
                }
                Engine currentEngine = new(model, power, displacement, efficiency);
                engines.Add(currentEngine);
            }

            List<Car> cars = new();
            int carCounter = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCounter; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                Engine engine = engines.FirstOrDefault(x => x.Model == carInfo[1]);
                int weight = 0;
                string color = null;
                bool isNotWeight = true;
                if (carInfo.Length >= 3)
                {
                    
                    isNotWeight = int.TryParse(carInfo[2] ,out  weight);
                }
                if(carInfo.Length == 3 && !isNotWeight)
                {
                    color = carInfo[2];
                }
                if (carInfo.Length == 4 )
                {
                    color = carInfo[3];
                }

                Car currentCar = new(model, engine, weight, color);
                cars.Add(currentCar);
            }
            Console.WriteLine(string.Join(Environment.NewLine , cars).TrimEnd());
        }
    }
}
