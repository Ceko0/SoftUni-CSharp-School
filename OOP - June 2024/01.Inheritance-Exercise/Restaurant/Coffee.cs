namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public  const double CopffeMilliliters = 50;
        public const decimal CoffeePrice = 3.50m;
        public double Caffeine { get; }
        public Coffee(string name, double caffeine) 
            : base(name, CoffeePrice, CopffeMilliliters)
        {           
            Caffeine = caffeine;
        }
    }
}
