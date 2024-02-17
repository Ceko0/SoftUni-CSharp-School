namespace _02.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;

            List<string> commands = Console.ReadLine()
                .Split("|" , StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int roomNumber = 0; roomNumber < commands.Count; roomNumber++)
            {
                List<string> currentRoom = commands[roomNumber] 
                    .Split()
                    .ToList();
                switch (currentRoom[0])
                {
                    case "potion":
                        
                        int currentHealth = health + int.Parse(currentRoom[1]);
                        if (currentHealth >= 100)
                        {
                            Console.WriteLine($"You healed for {100 - health } hp.");
                            health = currentHealth = 100;
                            
                        }
                        else
                        {
                            Console.WriteLine($"You healed for {currentRoom[1]} hp.");
                        }
                        
                        Console.WriteLine($"Current health: {currentHealth} hp.");
                        break;
                    case "chest":
                        Console.WriteLine($"You found {currentRoom[1]} bitcoins.");
                        bitcoins += int.Parse(currentRoom[1]);
                        break;
                    default:
                        health -= int.Parse(currentRoom[1]);
                        if (health <= 0)
                        {
                            Console.WriteLine($"You died! Killed by {currentRoom[0]}.");
                            Console.WriteLine($"Best room: {roomNumber+1}");
                            return;
                        }

                        Console.WriteLine($"You slayed {currentRoom[0]}.");
                        
                        break;
                }
            }
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");

        }
    }
}
