using WildFarm.Interfeces;

namespace WildFarm.Models.AnimalTree.MammalTree
{    
    public class Dog : Mammal, IProductSound
    {
        const double eatingCoefficient = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion, eatingCoefficient)
        {
        }
        public string ProductSound() => "Woof!";
    }
}
