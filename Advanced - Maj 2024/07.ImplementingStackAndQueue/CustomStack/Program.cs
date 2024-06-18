namespace CustomStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new("asd", "sdsa", "bsfd");
            stack.push("hello");
            Console.WriteLine("print elements");
            stack.ForEach(x => { Console.WriteLine(x); });
            Console.WriteLine(stack.pop());
            Console.WriteLine("print elements");
            stack.ForEach(x => { Console.WriteLine(x); });
            stack.push(stack.pop());
            Console.WriteLine("print elements");
            stack.ForEach(x => { Console.WriteLine(x); });
            Console.WriteLine($"print count {stack.Count}");
            Console.WriteLine($"print peek - > {stack.Peek()}");
        }
    }
}
