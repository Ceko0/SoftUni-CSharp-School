using WildFarm.Models.AnimalTree;
using WildFarm.Models.AnimalTree.BirdTree;
using WildFarm.Models.AnimalTree.MammalTree;
using WildFarm.Models.AnimalTree.MammalTree.FelineTree;

namespace WildFarm.ClassCreator
{
    public interface IAnimalCreator
    {
        public Animal CreateAnimal(string[] input)
        {
            string animalClass = input[0];
            switch (animalClass.ToLower())
            {
                case "owl":
                case "hen":
                    return BirdCreator(input);                    
                case "mouse":
                case "dog":
                    return MammalCreator(input);                    
                case "cat":
                case "tiger":
                    return FelineCreator(input);
                default:
                    throw new ArgumentException("Unknown animal class");
            }
        }
        public Animal BirdCreator(string[] input)
        {
            string birdType = input[0];
            string birdName = input[1];
            double wirght = double.Parse(input[2]);
            double WingSize = double.Parse(input[3]);
            if (birdType.ToLower() == "hen") return new Hen(birdName, wirght, WingSize);
            else return new Owl(birdName, wirght, WingSize);
        }
        public Animal FelineCreator(string[] input)
        {
            string type = input[0];
            string name = input[1];
            double winght = double.Parse(input[2]);
            string livingRegion = input[3];
            string breed = input[4];
            if (type.ToLower() == "cat") return new Cat(name, winght, livingRegion, breed);
            else return new Tiger(name, winght, livingRegion, breed);
        }
        public Animal MammalCreator(string[] input)
        {
            string type = input[0];
            string name = input[1];
            double weight = double.Parse(input[2]);
            string livingRegion = input[3];
            if (type.ToLower() == "dog") return new Dog(name, weight, livingRegion);
            else return new Mouse(name, weight, livingRegion);
        }
    }
}
