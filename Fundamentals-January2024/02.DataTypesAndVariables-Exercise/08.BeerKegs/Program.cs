namespace _08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kegCounter = int.Parse(Console.ReadLine());

            string biggestKeg = "";
            double biggestVolume = 0;
            for (int i = 0; i < kegCounter; i++)
            {
                string kegName = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHieght = int.Parse(Console.ReadLine());

                double kegVolume = Math.PI * Math.Pow(kegRadius, 2) * kegHieght;
                if (kegVolume >= biggestVolume)
                {
                    biggestKeg = kegName;
                    biggestVolume = kegVolume;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
