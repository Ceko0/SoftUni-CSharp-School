namespace _01._Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dayOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int incomeNumber = int.Parse(Console.ReadLine());
            if (incomeNumber <1 || incomeNumber > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine($"{dayOfWeek[incomeNumber - 1]}");
            }
        }
    }
}
