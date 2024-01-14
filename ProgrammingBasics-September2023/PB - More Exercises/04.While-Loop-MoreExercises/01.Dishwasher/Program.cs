int detergent = int.Parse(Console.ReadLine()) * 750;

int dishes = 0;
int pots = 0;
int totalDetergent = 0;
for (int i = 1; i != 0; i++)
{ 
    string income = Console.ReadLine();
    if (income == "End")
    {
        Console.WriteLine("Detergent was enough!");
        Console.WriteLine($"{dishes} dishes and {pots} pots were washed.");
        Console.WriteLine($"Leftover detergent {detergent - totalDetergent} ml.");
        break;
    }
    if (i % 3 == 0)
    {
        pots += int.Parse(income);
        totalDetergent += int.Parse(income) * 15;
    }
    else
    {
        dishes += int.Parse(income);
        totalDetergent += int.Parse(income) * 5;
    }

    if (detergent < totalDetergent)
    {
        Console.WriteLine($"Not enough detergent, {totalDetergent - detergent} ml. more necessary!");
        break;
    }
   

}