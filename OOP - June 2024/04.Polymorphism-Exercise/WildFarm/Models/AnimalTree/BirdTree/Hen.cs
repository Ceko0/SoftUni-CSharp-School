using WildFarm.Interfeces;
using WildFarm.Models.FoodTree;

namespace WildFarm.Models.AnimalTree.BirdTree
{
    public class Hen : Bird, IProductSound
    {
        const double eatingCoefficient = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize, eatingCoefficient)
        {
        }
        public string ProductSound() => "Cluck";
       
    }
}
