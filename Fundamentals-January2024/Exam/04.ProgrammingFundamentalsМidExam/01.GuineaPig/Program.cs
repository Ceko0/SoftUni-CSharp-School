namespace _01.GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double foodQuantity = double.Parse(Console.ReadLine());
            double quantityHay = double.Parse(Console.ReadLine());
            double quantityCover = double.Parse(Console.ReadLine());
            double guinesWeight = double.Parse(Console.ReadLine());

            double totalFood = foodQuantity * 1000;
            double totalHay = quantityHay * 1000;
            double totalCover = quantityCover * 1000;
            double guinesGrams = guinesWeight * 1000;
            for (int days = 1; days <= 30; days++)
            {
                totalFood -= 300;

                if (days % 2 == 0)
                {
                    totalHay -= totalFood *0.05;
                }

                if (days % 3 == 0)
                {
                    totalCover -= guinesGrams * 0.3333333333333333333333333;
                }
                if (totalFood <= 0 || totalCover <= 0 || totalHay <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }

            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {totalFood/ 1000 :f2}, Hay: {totalHay / 1000 :f2}, Cover: {totalCover / 1000:f2}.");
        }
    }
}
