int primeSum = 0;
int noPrimeSum = 0;
bool itsTrue = false;

while (true)
{
    string income =Console.ReadLine();
    if (income == "stop")
        break;


    int numb = int.Parse(income);
    if (numb < 0)
    {
        Console.WriteLine("Number is negative.");
        continue;
    }

    for (int i = 2; i < numb; i++)
    {
        itsTrue = false;
        if (numb % i == 0)
        {
            itsTrue = true;
            break;
        }
    }

    if (itsTrue)
    {
        noPrimeSum += numb;
        continue;
    } 
    primeSum += numb;
}
Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
Console.WriteLine($"Sum of all non prime numbers is: {noPrimeSum}");