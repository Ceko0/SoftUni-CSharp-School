int n = int.Parse(Console.ReadLine());
int counter = 1;
while (n >= counter)
{
    Console.WriteLine(counter);
    counter = counter * 2 + 1;
}