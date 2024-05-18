namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songList = new(Console.ReadLine()
                .Split(", " ,StringSplitOptions.RemoveEmptyEntries)
                );
            while(songList.Any() )
            {
                string[] commands = Console.ReadLine().Split();

                switch (commands[0])
                {
                    case "Play":
                        songList.Dequeue();
                        break;
                    case "Add":
                        string songName = string.Join(" ", commands.Skip(1));
                        if (!songList.Contains(songName))
                        {
                            songList.Enqueue(songName);
                        }
                        else
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", " , songList));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
