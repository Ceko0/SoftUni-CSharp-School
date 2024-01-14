//•	"Facebook"-> 150 лв.
//•	"Instagram"-> 100 лв.
//•	"Reddit"-> 50 лв.
int tabsNumber = int.Parse(Console.ReadLine());
int salary = int.Parse(Console.ReadLine());
for (int i = 0; i < tabsNumber; i++)
{ 
    string tabsName = Console.ReadLine();
    if (tabsName == "Facebook") salary -= 150;
    else if (tabsName == "Instagram") salary -= 100;
    else if (tabsName == "Reddit") salary -= 50;
    if (salary <= 0)
    {
        Console.WriteLine("You have lost your salary.");
        break;
    }
}
if (salary > 0) Console.WriteLine(salary);