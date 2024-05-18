
string input = Console.ReadLine();
Stack<char> charactersRevers  = new();
foreach (char c in input)
{
    charactersRevers.Push(c);
}
while (charactersRevers.Any())
{
    Console.Write(charactersRevers.Pop());
}