namespace Restaurant
{
    public class Dessert : Food
    {
        public double Calories { get;}
        public Dessert(string name, decimal price, double grams, double calories) 
            : base(name, price, grams)
        {
            Calories = calories;
        }
    }
}
