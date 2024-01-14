int height = int.Parse(Console.ReadLine());

int startingHeight = height - 30;
int jumps = 0;
int badJumps = 0;

while (true)
{ 
   

    int income = int.Parse(Console.ReadLine());

    if (income > startingHeight)
    {
        jumps++;
        if (startingHeight >= height)
        {
            Console.WriteLine($"Tihomir succeeded, he jumped over {height}cm after {jumps} jumps.");
            break;
        }
        badJumps = 0;
        startingHeight += 5;
    }
    else if (income <= startingHeight)
    {
        jumps++;
        badJumps++;
        if (badJumps == 3 )
        {
            Console.WriteLine($"Tihomir failed at {startingHeight}cm after {jumps} jumps.");
            break;
        }

    }
    
}