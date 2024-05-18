
Stack<int> numbers = new(Console.ReadLine()
    .Split()
    .Select(int.Parse));

while (true)
{
    string[] commands = Console.ReadLine()
    .ToLower()
    .Split()
    .ToArray()
    ;
    if (commands[0] == "end")
    {
        Console.WriteLine($"Sum: {numbers.Sum()}");
        return;
    }
    switch (commands[0])
    {
        case "add":
            numbers.Push(int.Parse(commands[1]));
            numbers.Push(int.Parse(commands[2]));

            break;
        case "remove":
            if (numbers.Count >= int.Parse(commands[1]))
            {
                for (int i = 0; i < int.Parse(commands[1]); i++)
                {
                    numbers.Pop();
                }
            }
            break;
    }
    
}