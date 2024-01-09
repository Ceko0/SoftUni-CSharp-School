int hours = int.Parse(Console.ReadLine());
int min = int.Parse(Console.ReadLine());
int totalMin = hours * 60 + min + 15;
int endHours = totalMin / 60;
int endMin = totalMin % 60;
if (endHours == 24) 
{
    endHours = 0;
}
Console.WriteLine($"{endHours}:{endMin :d2}");