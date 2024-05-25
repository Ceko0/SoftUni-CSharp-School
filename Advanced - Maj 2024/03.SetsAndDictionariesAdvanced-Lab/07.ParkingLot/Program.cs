namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = command[0];
                string number = command[1];
                if (direction == "IN")
                {
                    parking.Add(number);
                }
                else if (direction == "OUT")
                {
                    parking.Remove(number);
                }
            }
            if (parking.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, parking));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
