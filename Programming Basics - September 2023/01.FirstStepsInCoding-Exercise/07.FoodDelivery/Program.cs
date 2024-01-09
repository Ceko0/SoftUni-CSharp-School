int chikenMenu = int.Parse(Console.ReadLine());
int fishMenu = int.Parse(Console.ReadLine());
int vegMenu = int.Parse(Console.ReadLine());
double menuPrice = chikenMenu * 10.35 + fishMenu * 12.40 + vegMenu * 8.15;
double dessertPrice = menuPrice * 0.20;
Console.WriteLine(menuPrice + dessertPrice + 2.50);