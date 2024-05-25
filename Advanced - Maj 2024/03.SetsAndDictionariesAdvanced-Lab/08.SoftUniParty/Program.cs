
namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> reservation = new();
           
            while(true)
            {
                input = Console.ReadLine();
                if (input == "PARTY")
                {
                    while((input = Console.ReadLine()) != "END")
                    {
                        if(reservation.Contains(input))
                        {
                            reservation.Remove(input);
                        }                        
                    }
                    Console.WriteLine(reservation.Count);
                    Console.WriteLine(string.Join(Environment.NewLine, reservation.OrderByDescending(x => char.IsDigit(x[0]))));
                    return;
                }
                
                if ( input.Length == 8 )
                {
                    reservation.Add(input);
                }                
            }            
        }
    }
}
