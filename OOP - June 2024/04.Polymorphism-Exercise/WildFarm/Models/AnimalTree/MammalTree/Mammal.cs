namespace WildFarm.Models.AnimalTree.MammalTree
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion, double eatingCoefficient)
            : base(name, weight, eatingCoefficient)
        {
            LivingRegion = livingRegion;
        }
        public string LivingRegion { get; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
