namespace _8.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenTime = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            Queue<string> cars = new();
            int passedCounter = 0;

            while(input != "end")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < greenTime; i++)
                    {
                        if (cars.Any())
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCounter++;
                        }
                    }
                }
                
                input = Console.ReadLine();
            }
            Console.WriteLine($"{passedCounter} cars passed the crossroads.");
        }
    }
}
