using System.Numerics;

namespace _11.Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowball = int.Parse(Console.ReadLine());
            int bestSnowballSnow = 0;
            int bestSnowballTime = 0;
            int bestSnowballQuality = 0;
            BigInteger lastSnowballValue = 0;
            
            for (int i = 0; i < numberOfSnowball; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (snowballValue >= lastSnowballValue)
                {
                    bestSnowballSnow = snowballSnow ;
                    bestSnowballTime = snowballTime;
                    bestSnowballQuality = snowballQuality;
                    lastSnowballValue = snowballValue ;
                }
            }
            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {lastSnowballValue} ({bestSnowballQuality})");
        }
    }
}
