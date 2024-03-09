using System.ComponentModel;

namespace _03.Songs
{
    internal class Song
    {
        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }

        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            int songsNumber = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 1; i <= songsNumber; i++)
            {
                string[] songInfo = Console.ReadLine()
                    .Split("_");

                Song song = new Song(songInfo[0], songInfo[1], songInfo[2]);

                songs.Add(song);
            }
            string type = Console.ReadLine();

            switch (type)
            {
                case "all":
                    foreach (Song song in songs)
                    {
                        Console.WriteLine(song.Name);
                    }
                    break;
                default:
                    foreach (Song song in songs)
                    {
                        if (song.TypeList == type)
                        {
                            Console.WriteLine(song.Name);
                        }
                    }
                    break;
            }
        }
    }
}

