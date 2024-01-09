
int lostGame = int.Parse(Console.ReadLine());
double headsetPrice = double.Parse(Console.ReadLine());
double mousePrice = double.Parse(Console.ReadLine());
double keyboardPrice = double.Parse(Console.ReadLine());
double displayPrice = double.Parse(Console.ReadLine());
double totalPrice = 0;

int trashHeadset = 0;
int trashMouse = 0;
int trashKeyborad = 0;
int trashDisplay = 0;

for (int i = 1; i <= lostGame; i++)
{
    if (i % 12 == 0)
    {
        trashMouse++;
        trashHeadset++;
        trashKeyborad++;
        trashDisplay++;
    }
    else if (i % 6 == 0)
    {
        trashMouse++;
        trashHeadset++;
        trashKeyborad++;
    }
    else if (i % 3 == 0)
    {
        trashMouse++;
    }
    else if (i % 2 == 0)
    { 
    trashHeadset++;
    }
}
totalPrice = trashDisplay * displayPrice + trashKeyborad * keyboardPrice + trashMouse * mousePrice + trashHeadset * headsetPrice;

Console.WriteLine($"Rage expenses: {totalPrice:f2} lv.");