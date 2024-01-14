int v = int.Parse(Console.ReadLine());
int p1 = int.Parse(Console.ReadLine());
int p2 = int.Parse(Console.ReadLine());
double h = double.Parse(Console.ReadLine());
double p1Liters = p1 * h;
double p2Liters = p2 * h;
double totalwather = p1Liters+p2Liters;
if (v >= totalwather)
{
    double full = totalwather / v * 100;
    double p1Pro = p1Liters / totalwather * 100;
    double p2Pro = p2Liters / totalwather * 100;

    Console.WriteLine($"The pool is {$"{full:f2}"}% full. Pipe 1: {$"{p1Pro:f2}"}%. Pipe 2: {$"{p2Pro:f2}"}%.");
}
else
{
    Console.WriteLine($"For {$"{h:f2}"} hours the pool overflows with {$"{totalwather - v:f2}"} liters.");
}