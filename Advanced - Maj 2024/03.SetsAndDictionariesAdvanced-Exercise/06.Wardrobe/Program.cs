namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new();

            for (int i = 0; i < counter; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string[] clothes = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach (string dress in clothes)
                {
                    if (!wardrobe[color].ContainsKey(dress))
                    {
                        wardrobe[color].Add(dress, 0);
                    }
                    wardrobe[color][dress]++;
                }
            }
            string[] serch = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach((string color,Dictionary<string,int> dress) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach((string clothe , int value ) in dress)
                {
                    if (serch[0] ==color && serch[1] == clothe)
                    {
                        Console.WriteLine($"* {clothe} - {value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {clothe} - {value}");
                }
            }
        }
    }
}
