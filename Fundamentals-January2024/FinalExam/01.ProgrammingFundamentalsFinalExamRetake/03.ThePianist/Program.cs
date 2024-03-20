namespace _03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, string>> piecesList = new Dictionary<string, Dictionary<string, string>>();

            for (int i = 0; i < counter; i++)
            {
                string[] pieces = Console.ReadLine()
                    .Split("|")
                    .Select(x => x.Trim())
                    .ToArray();

                piecesList.Add(pieces[0], new Dictionary<string, string>());
                piecesList[pieces[0]].Add(pieces[1], pieces[2]);
            }

            string income = "";
            while ((income = Console.ReadLine()) != "Stop")
            {
                string[] commands = income
                    .Split("|")
                    .Select(x => x.Trim())
                    .ToArray();

                switch (commands[0])
                {
                    case "Add":
                        string piece = commands[1];
                        string composer = commands[2];
                        string key = commands[3];
                        if (piecesList.ContainsKey(piece))
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                            continue;
                        }
                        piecesList.Add(piece,new Dictionary<string, string>());
                        piecesList[piece].Add(composer, key);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        break;
                    case "Remove":
                        piece = commands[1];
                        if (piecesList.ContainsKey(piece))
                        {
                            piecesList.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                            continue;
                        }

                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        break;
                    case "ChangeKey":
                        piece = commands[1];
                        key = commands[2];
                        if (piecesList.ContainsKey(piece))
                        {
                            string currentComposer = piecesList[piece].Keys.First();
                            piecesList[piece].Remove(currentComposer);
                            piecesList[piece].Add(currentComposer , key);
                            Console.WriteLine($"Changed the key of {piece} to {key}!");
                            continue;
                        }

                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        break;
                }
            }

            foreach (var (piece , information) in piecesList)
            {
                foreach (var (composer , key) in information)
                {
                    Console.WriteLine($"{piece} -> Composer: {composer}, Key: {key}");
                }
                
            }
        }
    }
}
