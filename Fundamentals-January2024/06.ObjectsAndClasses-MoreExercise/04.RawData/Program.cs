namespace _04.RawData
{

    internal class Program
    {
        class Car
        {
            public Car(string model, Engine engine, Cargo cargo)
            {
                Model = model;
                Engine = engine;
                Cargo = cargo;
            }

            public string Model { get; set; }
            public Engine Engine { get; set; }
            public Cargo Cargo { get; set; }
            public override string ToString()
            {
                return $"{Model}";
            }
        }
        class Engine
        {
            public Engine(int speed, int power)
            {
                Speed = speed;
                Power = power;
            }

            public int Speed { get; set; }
            public int Power { get; set; }
        }
        class Cargo
        {
            public Cargo(int weight, string type)
            {
                Weight = weight;
                Type = type;
            }

            public int Weight { get; set; }
            public string Type { get; set; }
        }
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();
            int carNumbers = int.Parse(Console.ReadLine());
            for (int i = 0; i < carNumbers; i++)
            {
                string[] carInformation = Console.ReadLine()
                    .Split()
                    .ToArray();
                string model = carInformation[0];
                int power = int.Parse(carInformation[1]);
                int engineType = int.Parse(carInformation[2]);
                int weight = int.Parse(carInformation[3]);
                string cargoType = carInformation[4];
                Engine engine = new Engine(power, engineType);
                Cargo cargo = new Cargo(weight, cargoType);
                carList.Add(new Car(carInformation[0], engine, cargo));

            }
            string command = Console.ReadLine();
            switch (command)
            {
                case "fragile":
                    foreach (var car in carList)
                    {
                        if (car.Cargo.Type == "fragile" && car.Cargo.Weight < 1000)
                            Console.WriteLine(car);
                    }
                    break;
                case "flamable":
                    foreach (var car in carList)
                    {
                        if (car.Cargo.Type == "flamable" && car.Engine.Power > 250)
                            Console.WriteLine(car);
                    }
                    break;
            }
        }
    }
}
