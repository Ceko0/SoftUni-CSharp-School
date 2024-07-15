using WildFarm.ClassCreator;

namespace WildFarm.Models.FoodTree
{
    public abstract class Food :IFoodCreator
    {
        protected Food( string name ,int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public string Name { get; }
        public int Quantity { get; }
    }
}
