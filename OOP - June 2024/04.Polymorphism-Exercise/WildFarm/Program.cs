using WildFarm.ClassCreator;
using WildFarm.Interfeces;
using WildFarm.Models.AnimalTree;
using WildFarm.Models.FoodTree;

namespace WildFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animalCollection = new();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IAnimalCreator createAnimal = new AnimalCreator();
                Animal animal = createAnimal.CreateAnimal(animalInput);
                IProductSound soundAnimal = (IProductSound)animal;

                string[] foodInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IFoodCreator createdFood = new FoodCreator();
                Food food = createdFood.CreateFood(foodInput);
                Console.WriteLine(soundAnimal.ProductSound());
                if (DietCheck(food, soundAnimal))
                    animal.Eat(food);
                else
                    Console.WriteLine($"{animal.GetType().Name} does not eat {food.Name}!");

                animalCollection.Add(animal);
            }
            animalCollection.ForEach(animal => Console.WriteLine(animal));
        }

        private static bool DietCheck(Food food, IProductSound animal)
        {
            List<string> meat = new() { "dog", "cat", "tiger", "owl", "hen" };
            List<string> vegetable = new() { "cat", "mouse", "hen" };
            List<string> fruit = new() { "mouse", "hen" };
            List<string> seeds = new() { "hen" };
            string foodType = food.GetType().Name.ToLower();
            string animalType = animal.GetType().Name.ToLower();

            return foodType switch
            {
                "meat" => meat.Contains(animalType),
                "vegetable" => vegetable.Contains(animalType),
                "fruit" => fruit.Contains(animalType),
                "seeds" => seeds.Contains(animalType),
                _ => false
            };
        }

    }
}
