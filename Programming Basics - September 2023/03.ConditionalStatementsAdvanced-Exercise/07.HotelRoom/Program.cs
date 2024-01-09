string mesec = Console.ReadLine();
int days = int.Parse(Console.ReadLine());

switch (mesec)
{
    case "May":
    case "October":

        if (days > 7 && days <= 14)
        {
            Console.WriteLine($"Apartment: {days * 65:f2} lv.");
            Console.WriteLine($"Studio: {days * 50 * 0.95:f2} lv.");
        }
        else if (days > 14)
        {
            Console.WriteLine($"Apartment: {days * 65 * 0.90:f2} lv.");
            Console.WriteLine($"Studio: {days * 50 * 0.70:f2} lv.");
        }
        else 
        {
            Console.WriteLine($"Apartment: {days * 65 :f2} lv.");
            Console.WriteLine($"Studio: {days * 50 :f2} lv.");
        }
        break;
    case "June":
    case "September":
    
        if (days > 14)
        {
            Console.WriteLine($"Apartment: {days * 68.70 * 0.90:f2} lv.");
            Console.WriteLine($"Studio: {days * 75.20 * 0.80:f2} lv.");
        }
        else
        {
            Console.WriteLine($"Apartment: {days * 68.70 :f2} lv.");
            Console.WriteLine($"Studio: {days * 75.20:f2} lv.");
        }
        break;
        
    case "July":
    case "August":
 
        if (days > 14)
        {
            Console.WriteLine($"Apartment: {days * 77 * 0.90:f2} lv.");
            Console.WriteLine($"Studio: {days * 76:f2} lv.");
        }
        else
        {
            Console.WriteLine($"Apartment: {days * 77:f2} lv.");
            Console.WriteLine($"Studio: {days * 76:f2} lv.");
        }
        break;
}