using PizzaCalories;
using PizzaCalories.enums;
namespace PizzaCalories
{
    public class Topping
    {
        private static int MinWeight = 1;
        private static int MaxWeight = 50;
        private int _weight;
        private string _toppingType;

        public Topping(string toppingType, int weight)
        {
            if (!Enum.TryParse(toppingType, ignoreCase: true , out ToppingTypeEnums ToppingTypeValue))
                throw new ArgumentException($"Cannot place {toppingType} on top of your pizza.");
            if (weight < MinWeight || weight > MaxWeight) throw new ArgumentException($"{toppingType} weight should be in the range [{MinWeight}..{MaxWeight}].");
            ToppingType = toppingType;
            Weight = weight;
        }
        public int Weight { get => _weight; private set => _weight = value; }
        public string ToppingType { get => _toppingType; private set => _toppingType = value; }
        public string CalculateCalories()
        {
            double toppingCalories = ToppingType.ToLower() == "meat" ? 1.2 : ToppingType.ToLower() == "veggies" ? 0.8 : ToppingType.ToLower() == "cheese" ? 1.1 : 0.9;
            return (toppingCalories * Weight * 2).ToString("f2");
        }
    }
}
