namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string , int> minerBag = new Dictionary<string , int>();

            string income = "";
            while((income = Console.ReadLine()) != "stop")
            {
                string material = income;
                int quantity = int.Parse(Console.ReadLine());

                if (!minerBag.ContainsKey(material))
                {
                    minerBag.Add(material,0);
                }
                minerBag[material] += quantity;
            }

            foreach (var material in minerBag)
            {
                Console.WriteLine($"{material.Key} -> {material.Value}");
            }
        }
    }
}
