namespace _10.ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToList();


            string input = string.Empty;

            List<(string, string)> filters = new();

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] command = input
                    .Split(";" , StringSplitOptions.RemoveEmptyEntries);
                string filter = command[0];
                string operation = command[1];
                string value = command[2];

                if(filter == "Add filter")
                {
                    filters.Add((operation, value));
                }
                else
                {
                    filters.Remove((operation, value));
                }               
            }

            Func<List<string>, string, string, List<string>> filtration
                = (names, operation, value) =>
                {
                    return operation == "Starts with"
                    ? names.Where( x => x.StartsWith(value)).ToList()
                    : operation == "Ends with"
                    ? names.Where(x => x.EndsWith(value)).ToList()
                    : operation == "Contains"
                    ? names.Where( x => x.Contains(value) ).ToList()
                    :names.Where(x => x.Length == int.Parse(value)).ToList();                   
                };

            
            foreach ((string filter, string value )in filters)
            {
                List<string> blackList = filtration(people, filter, value);

                people = people.Where(x => !blackList.Contains(x)).ToList();
            }

            Console.WriteLine(string.Join(" ", people));
        }
    }
}
