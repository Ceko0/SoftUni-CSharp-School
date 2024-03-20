
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Food
    {
        public Food(string name, string data, int calories)
        {
            Name = name;
            Data = data;
            Calories = calories;
        }

        public string Name { get; set; }
        public string Data { get; set; }
        public int Calories { get; set; }
        public override string ToString()
        {
            return $"Item: {Name}, Best before: {Data}, Nutrition: {Calories}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string startingString = Console.ReadLine();
            
            List<Food> foods = new List<Food>();

            string pattern = @"(?<s>[#|])(?<Name>[A-Za-z\s]+)(\k<s>)(?<Date>\d{2}/\d{2}/\d{2})(\k<s>)(?<Calories>\d{1,4})(\k<s>)";
            MatchCollection matches = Regex.Matches(startingString, pattern);
            int totalCalories = 0;
            foreach (Match match in matches)
            {
                string name = match.Groups["Name"].Value;
                string date = match.Groups["Date"].Value;
                int calories = int.Parse(match.Groups["Calories"].Value);

                Food food = new Food(name, date, calories);
                foods.Add(food);
                totalCalories += calories;
            }

            int days = totalCalories / 2000;
            
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (var food in foods)
            {
                Console.WriteLine(food);
            }
        }
    }
}