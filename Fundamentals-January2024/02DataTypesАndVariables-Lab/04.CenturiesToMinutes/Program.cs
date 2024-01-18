namespace _04.CenturiesToMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int incomeCenturies = int.Parse(Console.ReadLine());
            int years = incomeCenturies * 100;
            double days = years * 365.2422;
            long hours = (int)days * 24;
            long minutes = hours * 60;
            Console.WriteLine($"{incomeCenturies} centuries = {years} years = {(int)days} days = {hours} hours = {minutes} minutes");
        }
    }
}
