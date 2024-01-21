namespace _03.FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            double difference = Math.Abs(firstNumber - secondNumber);

            if (difference < eps)
            {
                Console.WriteLine("True");
            }
            else if (difference >= eps)
            {
                Console.WriteLine("False");
            }
        }
    }
}
