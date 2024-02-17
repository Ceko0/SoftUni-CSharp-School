namespace _06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
            for (int i = 0; i < (Math.Min(firstPlayer.Count, secondPlayer.Count)); i++)
            {
                if (secondPlayer.Count < i) break;
                if (firstPlayer[i] > secondPlayer[i])
                {
                    firstPlayer.Add(secondPlayer[i]);
                    secondPlayer.RemoveAt(i);
                    firstPlayer.Add(firstPlayer[i]);
                    firstPlayer.RemoveAt(i);
                }
                else if (firstPlayer[i] < secondPlayer[i])
                {
                    secondPlayer.Add(firstPlayer[i]);
                    firstPlayer.RemoveAt(i);
                    secondPlayer.Add(secondPlayer[i]);
                    secondPlayer.RemoveAt(i);
                }
                else
                {
                    firstPlayer.RemoveAt(i);
                    secondPlayer.RemoveAt(i);
                }

                i = - 1;
            }
            if (GetLongestList(firstPlayer , secondPlayer)) Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
                    else Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
            
        }

        private static bool GetLongestList(List<int> firstPlayer, List<int> secondPlayer)
        {
            int maxLength = firstPlayer.Count;
            int secondLength = 0;
            foreach (var VARIABLE in secondPlayer)
            {
                secondLength++;
            }

            return (maxLength > secondLength);
        }
    }
}
/*
20 30 40 50
10 20 30 40
 */