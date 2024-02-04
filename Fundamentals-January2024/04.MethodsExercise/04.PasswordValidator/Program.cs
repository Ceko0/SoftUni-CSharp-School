using System.Linq;

namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isValed = PasworfValidCheck(password);
            if (isValed)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool PasworfValidCheck(string password)
        {
            int isValid = 0;
            
            if (LetterValidCheck(password))
            {
                isValid++;
            }

            if (OnllyLetterAndDiget(password))
            {
                isValid++;
            }

            if (digitCheck(password))
            {
                isValid++;
            }

            if (isValid == 3) return true; 
            else return false;
        }

        private static bool digitCheck(string password)
        {
            int digitCounter = 0;
            foreach (char currentCharacter in password)
            {
                if (char.IsDigit(currentCharacter))
                {
                    digitCounter++;
                }

            }

            if (digitCounter >= 2)
            {
                return true;
            }

            Console.WriteLine("Password must have at least 2 digits");
            return false;
        }

        private static bool OnllyLetterAndDiget(string password)
        {
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    return false;
                }
            }
            return true;
        }

        static bool LetterValidCheck(string pasword)
        {
            if (pasword.Length < 6 || pasword.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return false;
            }
            return true;
        }

    }
}
