using Breakout.GameObject;
using Breakout.Utilities;
using System.Xml.Linq;

namespace Breakout
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Console.BackgroundColor = ConsoleColor.White;
            Wall wall = new Wall(50, 40);
            Engine engine = new Engine(wall);
            engine.Run();
        }
    }
}
