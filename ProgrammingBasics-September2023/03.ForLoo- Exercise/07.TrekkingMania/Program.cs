int n = int.Parse(Console.ReadLine());
int totalPeople = 0;
int counter1 = 0;
int counter2 = 0;
int counter3 = 0;
int counter4 = 0;
int counter5 = 0;
for (int i = 0; i < n; i++)
{ 
    int people = int.Parse(Console.ReadLine());
    totalPeople += people;
    if (people <= 5) counter1 += people;
    else if (people <=12) counter2 += people;
    else if (people <= 25) counter3 += people;
    else if (people <= 40) counter4 += people;
    else counter5 += people;
}
Console.WriteLine($"{100.00 * counter1 / totalPeople:f2}%");
Console.WriteLine($"{100.00 * counter2 / totalPeople:f2}%");
Console.WriteLine($"{100.00 * counter3 / totalPeople:f2}%");
Console.WriteLine($"{100.00 * counter4 / totalPeople:f2}%");
Console.WriteLine($"{100.00 * counter5 / totalPeople:f2}%");