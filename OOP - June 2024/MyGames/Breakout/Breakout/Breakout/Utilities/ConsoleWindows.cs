using System.Runtime.InteropServices;
using System.Text;
namespace Breakout.Utilities
{
    public static class ConsoleWindow
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        public static void CustomizeConsole()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
        }
    }
}


