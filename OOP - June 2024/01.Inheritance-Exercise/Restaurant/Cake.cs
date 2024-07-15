namespace Restaurant
{
    public class Cake : Dessert
    {
        public static double DefaultGrams = 250;
        public static double DefaultCalories = 1000;
        public static decimal DefaultPrice = 5;

        public Cake(string name) : base(name, DefaultPrice, DefaultGrams, DefaultCalories)
        {
        }
    }
}
