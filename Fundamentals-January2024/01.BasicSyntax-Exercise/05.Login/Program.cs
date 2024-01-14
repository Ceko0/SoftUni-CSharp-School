
string userName = Console.ReadLine();
string pasword = "";
for (int j = userName.Length; j >0;  j--)
{
    pasword += userName[j -1];
}
for (int i = 1; i <= 4; i++)
{ 
    string incomePasword = Console.ReadLine();
    if (incomePasword == pasword)
    {
        Console.WriteLine($"User {userName} logged in.");
        return;
    }
    else
    {
        if (i == 4) continue; 
        Console.WriteLine("Incorrect password. Try again.");
    }
}
Console.WriteLine($"User {userName} blocked!");