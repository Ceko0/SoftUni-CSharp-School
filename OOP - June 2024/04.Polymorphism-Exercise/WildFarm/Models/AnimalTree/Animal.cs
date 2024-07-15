using WildFarm.ClassCreator;
using WildFarm.Interfeces;
using WildFarm.Models.FoodTree;

namespace WildFarm.Models.AnimalTree
{
    public abstract class Animal : IAnimalCreator, IEat
    {
        protected Animal(string name, double weight, double eatingCoefficient)
        {
            Name = name;
            Weight = weight;
            EatingCoefficient = eatingCoefficient;
        }
        
        public string Name { get; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; private set; }
        public double EatingCoefficient { get; }

        public void Eat(Food food)
        {            
            this.Weight += food.Quantity * EatingCoefficient;
            FoodEaten += food.Quantity;
        }
    }
}

