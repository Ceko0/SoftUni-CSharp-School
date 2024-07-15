using WildFarm.Interfeces;
using WildFarm.Models.FoodTree;

namespace WildFarm.Models.AnimalTree.BirdTree
{
    public class Owl : Bird, IProductSound
    {
        const double eatingCoefficient = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize, eatingCoefficient)
        {
        }
        public string ProductSound() => "Hoot Hoot";        
    }
}
