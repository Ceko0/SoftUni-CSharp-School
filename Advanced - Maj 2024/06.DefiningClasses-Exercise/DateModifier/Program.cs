namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateModifier dateModifier = new DateModifier();
            
            string dateOneStr = Console.ReadLine();
            
            string dateTwoStr = Console.ReadLine();
            
            int difference = dateModifier.CalculateDifference(dateOneStr, dateTwoStr);
            Console.WriteLine(difference);
        }
    }
}
