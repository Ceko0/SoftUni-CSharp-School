string text = Console.ReadLine();
int sum = 0;
for (int i = 0; i < text.Length; i++)
{
    char simbol = text[i];
    if (simbol == 'a') sum +=1;
    else if (simbol == 'e') sum += 2;
    else if (simbol == 'i') sum += 3;
    else if (simbol == 'o') sum += 4;
    else if (simbol == 'u') sum += 5;
}
Console.WriteLine(sum);