namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            double powerNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(NumberPow(baseNumber , powerNumber));
        }

        static double NumberPow(double baseNumber, double powerNumber)
        {
            double poweredNumber = baseNumber;
            for (int i = 1; i < powerNumber; i++)
            {
                poweredNumber *= baseNumber;
            }
            return poweredNumber;
        }
    }
}
