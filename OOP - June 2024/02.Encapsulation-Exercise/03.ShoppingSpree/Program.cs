using System.Linq;
using System.Xml.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            
            Dictionary<string ,Person> peopleList = new();
            List<string> orderPeople = new();
            Dictionary<string,Product> productsList = new();
            try
            {
                for (int i = 0; i < people.Length; i++)
                {
                    string[] personInfo = people[i].Split('=');
                    peopleList[personInfo[0]] = new(personInfo[0], decimal.Parse(personInfo[1]));
                    orderPeople.Add(personInfo[0]);
                }
                for (int i = 0; i < products.Length; i++)
                {
                    string[] productInfo = products[i].Split('=');
                    productsList[productInfo[0]] = new(productInfo[0], decimal.Parse(productInfo[1]));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] buyInfo = input.Split();

                Person currPerson = peopleList[buyInfo[0]];
                Product currProduct = productsList[buyInfo[1]];
                if (currPerson.TryBuy(currProduct) ) Console.WriteLine($"{currPerson.Name} bought {currProduct.Name}");
                else Console.WriteLine(($"{currPerson.Name} can't afford {currProduct.Name}"));
            }
            orderPeople.ForEach(p => Console.WriteLine(peopleList[p]));            
        }
    }
}
