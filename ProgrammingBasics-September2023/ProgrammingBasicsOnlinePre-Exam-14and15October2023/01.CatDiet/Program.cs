int fats = int.Parse(Console.ReadLine());
int proteins  = int.Parse(Console.ReadLine());
int carbohydrates = int.Parse(Console.ReadLine());
int kaorium  = int.Parse(Console.ReadLine());
int water =  int.Parse(Console.ReadLine());

double totalFats = (kaorium * fats / 100.0) / 9;
double totalProteins = (kaorium * proteins / 100.0) / 4;
double totalCarbohydrates = (kaorium * carbohydrates / 100.0) / 4;
double totalFood = totalFats + totalProteins + totalCarbohydrates;
double totalKaorium = kaorium / totalFood;

Console.WriteLine($"{totalKaorium * (100 -water) / 100:f4}");