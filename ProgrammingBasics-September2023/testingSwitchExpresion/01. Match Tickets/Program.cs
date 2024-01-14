double budget = double.Parse(Console.ReadLine());
string tipe  = Console.ReadLine();
int countOfPeople = int.Parse(Console.ReadLine());

double moneyLeft = 0;

(moneyLeft) = (countOfPeople) switch
{ 
   <= 4 => budget * 0.25, <= 9 => budget * 0.40 , <= 24 => budget * 0.50 , <= 49 => budget * 0.60 , >= 50  => budget * 0.75
};

if (moneyLeft > countOfPeople * 499.99 && tipe == "VIP") Console.WriteLine($"Yes! You have {moneyLeft - countOfPeople * 499.99:f2} leva left.");
else if (moneyLeft > countOfPeople * 249.99 && tipe == "Normal") Console.WriteLine($"Yes! You have {moneyLeft - countOfPeople * 249.99:f2} leva left.");
else if (moneyLeft < countOfPeople * 499.99 && tipe == "VIP") Console.WriteLine($"Not enough money! You need {countOfPeople * 499.99 - moneyLeft:f2} leva.");
else Console.WriteLine($"Not enough money! You need {countOfPeople * 249.99 - moneyLeft:f2} leva.");


//if (tipe == "IP") _ = count <= 4 ? budget * 0.75 : count <= 9 ? budget * 0.6 : count <= 24 ? budget * 0.50 : count <= 49 ? budget * 0.40 : budget * 0.25;
//if (tipe == "Normal") _ = count <= 4 ? budget * 0.75 : count <= 9 ? budget * 0.6 : count <= 24 ? budget * 0.50 : count <= 49 ? budget * 0.40 : budget * 0.25;
