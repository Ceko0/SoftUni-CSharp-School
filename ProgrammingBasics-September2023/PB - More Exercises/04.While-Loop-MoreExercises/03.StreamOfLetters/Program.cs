
string income = "";

int  counterC = 0;
int  counterO = 0;
int  counterN = 0;
string leather = "";

while (true)
{
    income = Console.ReadLine();

    if (counterC == 1 && counterO == 1 && counterN == 1)
    {
        Console.Write($"{leather} ");
        leather = "";   
        counterC = 0;
        counterO = 0;
        counterN = 0;
    } 

    if (income == "End")
    {
        break;
    }

    if (income == "c" && counterC == 0) { counterC++; continue; }
    else if (income == "o" && counterO == 0) { counterO++; continue; }
    else if (income == "n" && counterN == 0) { counterN++; continue; }
    char test = char.Parse(income);

    if (char.IsLetter(test))
    {
        leather += test;
    }
        /*
         if (income == "A" || income == "B" || income == "C" || income == "D" || income == "E" || income == "F" || income == "G" || income == "H" || income == "I" || income == "J" || income == "K" || income == "L" || income == "M" || income == "N" || income == "O" || income == "P" || income == "Q" || income == "R" || income == "S" || income == "T" || income == "U" || income == "V" || income == "W" || income == "X" || income == "Y" || income == "Z")
         {
             leather += income;
         }
         else if (income == "a" || income == "b" || income == "c" || income == "d" || income == "e" || income == "f" || income == "g" || income == "h" || income == "i" || income == "j" || income == "k" || income == "l" || income == "m" || income == "n" || income == "o" || income == "p" || income == "q" || income == "r" || income == "s" || income == "t" || income == "u" || income == "v" || income == "w" || income == "x" || income == "y" || income == "z")
         {
             leather += income;
         }
         */
}
