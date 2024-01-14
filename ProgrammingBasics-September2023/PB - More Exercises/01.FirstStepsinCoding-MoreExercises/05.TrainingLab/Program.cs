
using System;

namespace _05.TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double h = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            h = h * 100;
            w = w *100 - 100;
            double seedh =Math.Floor( h / 120);
            double seedw = Math.Floor(w / 70);
            double totalseed = seedh * seedw - 3;
            Console.WriteLine(totalseed);
        }
    }
}
