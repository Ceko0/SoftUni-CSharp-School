
namespace _06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sideA = int.Parse(Console.ReadLine());
            double sideB = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateRectangleArea(sideA, sideB));
        }

        static double CalculateRectangleArea(double sideA, double sideB)
        {
            return (sideA * sideB);
        }
    }
}
