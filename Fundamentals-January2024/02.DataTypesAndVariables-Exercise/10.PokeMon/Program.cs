namespace _10.PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine()); 
            int distance = int.Parse(Console.ReadLine()); 
            int exhaustionFactor = int.Parse(Console.ReadLine());
            double midlePower = pokePower / 2;
            int pokedTargets = 0;
            while (pokePower > 0)
            {
                if (pokePower == midlePower)
                {
                    if (exhaustionFactor != 0)
                    {
                        pokePower = pokePower / exhaustionFactor;
                    }
                }
                if (pokePower >= distance)
                {
                    pokePower -= distance;
                    pokedTargets++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargets);
        }
    }
}
