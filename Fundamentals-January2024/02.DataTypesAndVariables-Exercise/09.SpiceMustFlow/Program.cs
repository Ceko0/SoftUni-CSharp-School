using System.Diagnostics.Metrics;
using System.Numerics;

namespace _09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYieldOfSource = int.Parse(Console.ReadLine());
            ulong minedSpice = 0;
            int SpiceLeft = startingYieldOfSource;
            int dayCounter = 0;

            while (true)
            {

                if (SpiceLeft < 100)
                {
                    break;
                }
                else
                {
                    minedSpice += (ulong)SpiceLeft;
                    SpiceLeft -= 10;
                    minedSpice -= 26;
                    dayCounter++;
                }
            }
            if (minedSpice >= 26)
            {
                minedSpice -= 26;
            }
           
                Console.WriteLine(dayCounter);
                Console.WriteLine(minedSpice);
            
        }
    }
}
