int stadiumCapacity = int.Parse(Console.ReadLine());
int fensNumber = int.Parse(Console.ReadLine());

double sectorA = 0;
double sectorB = 0;
double sectorV = 0;
double sectorG = 0;    

for (int i = 0; i < fensNumber; i++)
{ 
    string sector = Console.ReadLine();
    _ = sector == "A" ? sectorA++ : sector == "B" ? sectorB++ : sector == "V" ? sectorV++ : sectorG++;
}
Console.WriteLine($"{sectorA / fensNumber * 100:f2}%");
Console.WriteLine($"{sectorB / fensNumber * 100:f2}%");
Console.WriteLine($"{sectorV / fensNumber * 100:f2}%");
Console.WriteLine($"{sectorG / fensNumber * 100:f2}%");
Console.WriteLine($"{(sectorA + sectorB + sectorV + sectorG)/stadiumCapacity * 100:f2}%");