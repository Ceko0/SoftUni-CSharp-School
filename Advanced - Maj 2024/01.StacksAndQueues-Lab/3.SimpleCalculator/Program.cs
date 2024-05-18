
Stack<string> input = new(
                Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Reverse()
                 );

int result = int.Parse(input.Pop() );

while (input.Any())
{
    string operation = input.Pop();
    
    switch (operation)
    {
        case "+":
            result += int.Parse(input.Pop());
            break;
        case "-":
            result -= int.Parse(input.Pop());
            break;
    }
}
Console.WriteLine(result);
