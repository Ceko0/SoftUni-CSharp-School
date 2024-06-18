namespace CustomStack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new();

            string input = string.Empty;

            while((input = Console.ReadLine()) != "END") 
            {
                string[] commands = input
                    .Split(new char[] {',' ,' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                switch (commands[0])
                {
                    case "Push":
                        foreach(string item in commands.Skip(1))
                        {
                            stack.Push(int.Parse(item));
                        }
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }                        
                        break;                    
                }
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
