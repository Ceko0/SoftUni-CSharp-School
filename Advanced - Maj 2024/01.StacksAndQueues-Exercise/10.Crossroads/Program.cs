namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int green = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new();
            int carCounter = 0;
            string input = string.Empty;

            while((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int currentGreen = green;
                    string currentCar = string.Empty; 
                    while(currentGreen > 0 && cars.Any())
                    {
                        currentCar = cars.Dequeue();
                        if (currentCar.Length <= currentGreen)
                        {
                            currentGreen -= currentCar.Length;
                            carCounter++;
                        }
                        else
                        {
                            currentGreen -= currentCar.Length;
                            if (currentGreen + freeWindow < 0)
                            {
                                char hitPoint = currentCar[currentCar.Length + currentGreen + freeWindow];
                                Console.WriteLine($"A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {hitPoint}.");
                                return;
                            }
                            carCounter++;
                        }
                    }                    
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{carCounter} total cars passed the crossroads.");
        }
    }
}
