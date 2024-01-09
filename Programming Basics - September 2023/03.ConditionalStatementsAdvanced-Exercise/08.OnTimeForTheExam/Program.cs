int examHours = int.Parse(Console.ReadLine());
int examMin = int.Parse(Console.ReadLine());
int arrivalHours = int.Parse(Console.ReadLine());
int arrivalMin = int.Parse(Console.ReadLine());

int examTotal = examHours * 60 + examMin;
int arrivalTotal = arrivalHours * 60 + arrivalMin;
int studentTime = arrivalTotal - examTotal;
int studentHours = Math.Abs(studentTime) / 60;
int studentMin = Math.Abs(studentTime) % 60 ;

if (studentTime < 0 && studentTime >= -30)
{
    Console.WriteLine("On time");
    Console.WriteLine($"{Math.Abs(studentTime)} minutes before the start");
}
else if (studentTime == 0) 
{
    Console.WriteLine("On time");
}
else if (studentTime < 0)
{
    if (Math.Abs(studentTime) <= 59)
    {
        Console.WriteLine("Early");
        Console.WriteLine($"{Math.Abs(studentTime)} minutes before the start");
    }
    else
    {
        Console.WriteLine("Early");
        Console.WriteLine($"{studentHours}:{studentMin:d2} hours before the start");
    }
}
else
{
    if (studentTime <= 59)
    {
        Console.WriteLine("Late");
        Console.WriteLine($"{Math.Abs(studentTime)} minutes after the start");
    }
    else
    {
        Console.WriteLine("Late");
        Console.WriteLine($"{studentHours}:{studentMin:d2} hours after the start");
    }
}