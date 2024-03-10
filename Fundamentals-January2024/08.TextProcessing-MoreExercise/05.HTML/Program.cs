using System.Text;

namespace _05.HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            string income = "";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h1>");
            sb.AppendLine(title);
            sb.AppendLine("</h1>");
            sb.AppendLine("<article>");
            sb.AppendLine(content);
            sb.AppendLine("</article>");
            while ((income = Console.ReadLine()) != "end of comments")
            {
                sb.AppendLine("<div>");
                sb.AppendLine(income);
                sb.AppendLine("</div>");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
