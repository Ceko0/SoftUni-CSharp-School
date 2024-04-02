namespace _02.TaxCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> vehicleInfo = Console.ReadLine()
                .Split(">>")
                .ToList();
            double taxSum = 0;
            for (int i = 0; i < vehicleInfo.Count; i++)
            {
                List<string> currentCar = vehicleInfo[i]
                    .Split()
                    .ToList();
                double tax = 0;

                switch (currentCar[0])
                {
                    case "family":
                        tax += 50;
                        double years = double.Parse(currentCar[1]);
                        double kilometers = double.Parse(currentCar[2]);
                        while (years != 0)
                        {
                            years--;
                            tax -= 5;
                        }
                        while (kilometers >= 3000)
                        {
                            kilometers -= 3000;
                            tax += 12;
                        }

                        Console.WriteLine($"A family car will pay {tax:f2} euros in taxes.");
                        taxSum += tax;
                        break;
                    case "heavyDuty":
                        tax += 80;
                        years = double.Parse(currentCar[1]);
                        kilometers = double.Parse(currentCar[2]);
                        while (years != 0)
                        {
                            years--;
                            tax -= 8;
                        }
                        while (kilometers >= 9000)
                        {
                            kilometers -= 9000;
                            tax += 14;
                        }

                        Console.WriteLine($"A heavyDuty car will pay {tax:f2} euros in taxes.");
                        taxSum += tax;
                        break;
                    case "sports":
                        tax += 100;
                        years = double.Parse(currentCar[1]);
                        kilometers = double.Parse(currentCar[2]);
                        while (years != 0)
                        {
                            years--;
                            tax -= 9;
                        }
                        while (kilometers >= 2000)
                        {
                            kilometers -= 2000;
                            tax += 18;
                        }

                        Console.WriteLine($"A sports car will pay {tax:f2} euros in taxes.");
                        taxSum += tax;
                        break;
                    default:
                        Console.WriteLine($"Invalid car type.");
                        break;
                }
            }

            Console.WriteLine($"The National Revenue Agency will collect {taxSum:f2} euros in taxes.");
        }
    }
}
