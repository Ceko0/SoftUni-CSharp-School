
int income = int.Parse(Console.ReadLine());

if(income % 10 == 0) Console.WriteLine("The number is divisible by 10");
else if(income % 7 == 0) Console.WriteLine("The number is divisible by 7");
else if(income % 6 == 0) Console.WriteLine("The number is divisible by 6");
else if(income % 3 == 0) Console.WriteLine("The number is divisible by 3");
else if(income % 2 == 0) Console.WriteLine("The number is divisible by 2");
else Console.WriteLine("Not divisible");