namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                double startingExperience = double.Parse(Console.ReadLine());
                double countOfBattle = double.Parse(Console.ReadLine());
                double experienceCollect = 0;

                for (int i = 1; i <= countOfBattle; i++)
                {
                    double needExperience = double.Parse(Console.ReadLine());

                    if (i % 3 == 0)
                    {
                        needExperience *= 1.15;
                    }

                    if (i % 5 == 0)
                    {
                        needExperience *= 0.90;
                    }

                    if (i % 15 == 0)
                    {
                        needExperience *= 1.05;
                    }
                    experienceCollect += needExperience;

                    if (experienceCollect >= startingExperience)
                    {
                        Console.WriteLine($"Player successfully collected his needed experience for {i} battles.");
                        return;
                    }
                }

                Console.WriteLine($"Player was not able to collect the needed experience, {startingExperience - experienceCollect} more needed.");
            }
        }
    }
}
