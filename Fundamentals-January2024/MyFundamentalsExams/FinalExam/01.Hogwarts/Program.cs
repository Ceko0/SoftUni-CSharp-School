namespace _01.Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();

            string income = String.Empty;
            while ((income = Console.ReadLine()) != "Abracadabra")
            {
                string[] commands = income
                    .Split()
                    .ToArray();

                string command = commands[0];

                switch (command)
                {
                    case "Abjuration":
                        spell = spell.ToUpper();
                        Console.WriteLine(spell);
                        break;
                    case "Necromancy":
                        spell = spell.ToLower();
                        Console.WriteLine(spell);
                        break;
                    case "Illusion":
                        int index = int.Parse(commands[1]);
                        string letter = commands[2];
                        if (index >= 0 && index < spell.Length)
                        {
                            spell = spell.Remove(index, 1);
                            spell = spell.Insert(index, letter);
                            Console.WriteLine("Done!");
                        }
                        else Console.WriteLine("The spell was too weak.");

                        break;
                    case "Divination":
                        string firstSubstring = commands[1];
                        string secondSubstring = commands[2];
                        if (spell.Contains(firstSubstring))
                        {
                            spell = spell.Replace(firstSubstring, secondSubstring);
                            Console.WriteLine(spell);
                        }
                        break;
                    case "Alteration":
                        string substring = commands[1];
                        if (spell.Contains(substring))
                        {
                            int startIndex = spell.IndexOf(substring);
                            spell = spell.Remove(startIndex, substring.Length);
                            Console.WriteLine(spell);
                        }
                        break;
                    default:
                        Console.WriteLine("The spell did not work!");
                        break;
                }
            }
        }
    }
}
