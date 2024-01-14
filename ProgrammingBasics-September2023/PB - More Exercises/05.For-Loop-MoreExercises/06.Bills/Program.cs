int monthForCheck = int.Parse(Console.ReadLine());

double electricityBill = 0;
int waterBill = 0;
int internetBill = 0;
double otherBill = 0;

for (int i = 1; i <= monthForCheck; i++)
{ 
    double electricityBillPerMonth = double.Parse(Console.ReadLine());
    electricityBill += electricityBillPerMonth;
    waterBill += 20;
    internetBill += 15;
    otherBill += (electricityBillPerMonth + 20 +15 ) * 1.20;
}

double AverageBill = (electricityBill + waterBill + internetBill + otherBill) / 5;
Console.WriteLine($"Electricity: {electricityBill:f2} lv");
Console.WriteLine($"Water: {waterBill:f2} lv");
Console.WriteLine($"Internet: {internetBill} lv");
Console.WriteLine($"Other: {otherBill:f2} lv");
Console.WriteLine($"Average: {AverageBill:f2} lv");