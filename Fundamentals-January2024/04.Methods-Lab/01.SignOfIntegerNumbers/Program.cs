namespace _01.SignOfIntegerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"The number {number} is {IntChek(number)}. ");            
        }

        static string IntChek(int number)
        {
            if (number < 0) return "negative";
            else if (number > 0) return "positive";
            else return "zero";
        }
    }
}
