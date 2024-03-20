namespace _01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string startingStops = Console.ReadLine();

            string income = "";
            while ((income = Console.ReadLine()) != "Travel")
            {
                string[] commands = income
                    .Split(":");

                switch (commands[0])
                {
                    case "Add Stop":
                        int startIndex = int.Parse(commands[1]);
                        string letterToAdd = commands[2];
                        if (startIndex >= 0 && startIndex <= startingStops.Length - 1)
                        {
                            startingStops = startingStops.Insert(startIndex, letterToAdd);
                        }
                        break;
                    case "Remove Stop":
                        startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        if (startIndex >= 0 && startIndex <= startingStops.Length - 1 && endIndex >= 0 && endIndex <= startingStops.Length - 1)
                        {
                            startingStops = startingStops.Remove(startIndex, endIndex - startIndex +1);
                        }
                        break;
                    case "Switch":
                        string oldLetter = commands[1];
                        string newLetter = commands[2];
                        if (startingStops.Contains(oldLetter))
                        {
                            startingStops = startingStops.Replace(oldLetter, newLetter);
                        }
                        break;
                }

                Console.WriteLine(startingStops);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {startingStops}");
        }
    }
}
