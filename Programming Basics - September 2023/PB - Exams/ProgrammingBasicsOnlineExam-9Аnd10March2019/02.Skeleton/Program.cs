int controlMin = int.Parse(Console.ReadLine());
int controlSeconds = int.Parse(Console.ReadLine());
double length = double.Parse(Console.ReadLine());
int secondsFor100 = int.Parse(Console.ReadLine());

int controlTime = controlMin *60 + controlSeconds;
double slowingTime = (length / 120) * 2.5; 
double MarinTime = (length /100) * secondsFor100 - slowingTime;

if (controlTime >= MarinTime)
{
    Console.WriteLine("Marin Bangiev won an Olympic quota!");
    Console.WriteLine($"His time is {MarinTime:f3}.");
}
else Console.WriteLine($"No, Marin failed! He was {MarinTime - controlTime:f3} second slower.");



