int firstTime = int.Parse(Console.ReadLine());
int secondTime = int.Parse(Console.ReadLine());
int thirdTime = int.Parse(Console.ReadLine());
int totalTime = firstTime + secondTime + thirdTime;
int hours = totalTime / 60;
int minuts = totalTime % 60;
Console.WriteLine($"{hours}:{minuts :d2}");