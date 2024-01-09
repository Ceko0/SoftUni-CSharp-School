
int countOfOrders = int.Parse(Console.ReadLine());

double totalPrice = 0;

for (int i = 0; i < countOfOrders; i++)
{ 
    double capsulePrice = double.Parse(Console.ReadLine());
    int day = int.Parse(Console.ReadLine());
    int capsulCount = int.Parse(Console.ReadLine());

    double orderPrice = (day * capsulCount) * capsulePrice;
    totalPrice += orderPrice;
    Console.WriteLine($"The price for the coffee is: ${orderPrice:f2}");
}
Console.WriteLine($"Total: ${totalPrice:f2}");