int winGames = 0;
int loseGames = 0;
int totalGames = 0;
while (true)
{
    string turnament = Console.ReadLine();
    if (turnament == "End of tournaments") break;
    int matchеs = int.Parse(Console.ReadLine());

    for (int i = 1; i <= matchеs; i++)
    {

        int desiTeamPoints = int.Parse(Console.ReadLine());
        int enemyTeamPoints = int.Parse(Console.ReadLine());
        totalGames++;
        if (enemyTeamPoints < desiTeamPoints)
        {
            winGames++;
            Console.WriteLine($"Game {i} of tournament {turnament}: win with {desiTeamPoints - enemyTeamPoints} points.");
        }
        else
        { 
            loseGames++;
            Console.WriteLine($"Game {i} of tournament {turnament}: lost with {enemyTeamPoints - desiTeamPoints} points.");
        }
    }


}
Console.WriteLine($"{(double)winGames / totalGames * 100 :f2}% matches win");
Console.WriteLine($"{(double)loseGames / totalGames * 100 :f2}% matches lost");

