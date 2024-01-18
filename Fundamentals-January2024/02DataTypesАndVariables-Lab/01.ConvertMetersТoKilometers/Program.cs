namespace _01.ConvertMetersТoKilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int incomeMeters = int.Parse(Console.ReadLine());
            Console.WriteLine($"{incomeMeters / 1000.0 :f2}");
        }
    }
}
