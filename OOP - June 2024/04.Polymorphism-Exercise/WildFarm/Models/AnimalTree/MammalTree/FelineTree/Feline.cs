namespace WildFarm.Models.AnimalTree.MammalTree.FelineTree
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight,  string livingRegion, string breed,double eatingCoefficient) 
            : base(name, weight, livingRegion, eatingCoefficient)
        {
            Breed = breed;
        }
        public string Breed { get;}
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
