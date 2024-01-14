int number = int.Parse(Console.ReadLine());
bool result = number >= 100 && number <= 200 || number == 0;
if (!result)
{
    Console.WriteLine("invalid");
}