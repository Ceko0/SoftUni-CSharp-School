double record = double.Parse(Console.ReadLine());
double distance = double.Parse(Console.ReadLine());
double time  = double.Parse(Console.ReadLine());
double ivanTime = (distance * time + (Math.Floor(distance / 15)*12.5));
if (record > ivanTime)
{
    Console.WriteLine($" Yes, he succeeded! The new world record is {ivanTime:f2} seconds.");
}
else
{ 
    Console.WriteLine($"No, he failed! He was { ivanTime - record:f2} seconds slower.");
}