namespace _01.ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> moneyInPocket = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> priceOfFood = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int eatenFood = 0;

            while (moneyInPocket.Count > 0 && priceOfFood.Count > 0)
            {
                int currentMoney = moneyInPocket.Pop();
                int currentPrice = priceOfFood.Dequeue();

                if(currentMoney == currentPrice)
                {
                    eatenFood ++;
                }
                else if (currentMoney > currentPrice)
                {
                    if(moneyInPocket.Count == 0)
                    {
                        moneyInPocket.Push(currentMoney - currentPrice);
                    }
                    else
                    {
                        moneyInPocket.Push(moneyInPocket.Pop() + currentMoney - currentPrice);
                    }
                   
                    eatenFood++;
                }
            }
            if(eatenFood >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {eatenFood} foods.");
            }
            else if (eatenFood >= 1)
            {
                string foods = eatenFood == 1 ? "food" : "foods";
                Console.WriteLine($"Henry ate: {eatenFood} {foods}.");
            }
            else
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}
