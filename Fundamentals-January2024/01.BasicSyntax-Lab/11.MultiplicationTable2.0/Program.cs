
int number = int.Parse(Console.ReadLine());
int startingNumber = int.Parse(Console.ReadLine());

//if (startingNumber > 10)
//    Console.WriteLine($"{number} X {startingNumber} = {number * startingNumber}");
//else
//{
//    for (int i = startingNumber; i < 11; i++)
//    {
//        Console.WriteLine($"{number} X {i} = {number * i}");
//    }
//}

do
{
    Console.WriteLine($"{number} X {startingNumber} = {number * startingNumber}");
    startingNumber++;
} while (startingNumber <= 10);