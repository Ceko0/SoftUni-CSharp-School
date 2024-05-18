namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int manipulation = int.Parse(Console.ReadLine());

            Stack<string> startText = new();
            string textToManipulate = string.Empty;

            for (int i = 0; i < manipulation; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split();

                switch (commands[0])
                {

                    case "1":

                        startText.Push(textToManipulate);
                            textToManipulate += commands[1];
                        
                        break;
                    case "2":
                        startText.Push(textToManipulate);
                        int removeCount = int.Parse(commands[1]);
                        textToManipulate = textToManipulate.Remove(textToManipulate.Length - removeCount);
                        break;
                    case "3":
                        Console.WriteLine(textToManipulate[int.Parse(commands[1]) - 1]);
                        break;
                    case "4":
                        textToManipulate = startText.Pop();
                        break;
                }
            }
        }
    }
}

