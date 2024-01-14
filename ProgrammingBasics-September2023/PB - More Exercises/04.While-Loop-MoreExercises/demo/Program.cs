using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder currentWord = new StringBuilder();
        bool cFound = false;
        bool oFound = false;
        bool nFound = false;

        while (true)
        {
            char symbol = char.Parse(Console.ReadLine());

            if (symbol == 'E' && cFound && oFound && nFound)
            {
                // Командата "End" е намерена, приключваме четенето.
                break;
            }

            if (char.IsLetter(symbol))
            {
                if (symbol == 'c' && !cFound)
                {
                    cFound = true;
                }
                else if (symbol == 'o' && cFound && !oFound)
                {
                    oFound = true;
                }
                else if (symbol == 'n' && cFound && oFound && !nFound)
                {
                    nFound = true;
                }
                else
                {
                    // Добавяме буквата към текущата дума.
                    currentWord.Append(symbol);
                }
            }
            else if (symbol == ' ')
            {
                // Печатаме текущата дума и готвим за следваща.
                Console.Write(currentWord + " ");
                currentWord.Clear();
                cFound = oFound = nFound = false;
            }
        }
    }
}
