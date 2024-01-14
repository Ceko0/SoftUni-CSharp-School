
string incomeNumber = Console.ReadLine();
int number = int.Parse(incomeNumber);

int sumOfCurentfactorials = 0;

for (int i = incomeNumber.Length -1; i >= 0; i--)
{
    int curentnumber = incomeNumber[i] - '0';
    int factorialOfCurentNumb = curentnumber;
    if (curentnumber == 0) sumOfCurentfactorials += 1;
    for (int j = (curentnumber -1 ); j > 0; j--)
    {
        factorialOfCurentNumb *= j;
    }
    sumOfCurentfactorials += factorialOfCurentNumb;
}

if  (sumOfCurentfactorials == number) Console.WriteLine("yes");
else  Console.WriteLine("no");