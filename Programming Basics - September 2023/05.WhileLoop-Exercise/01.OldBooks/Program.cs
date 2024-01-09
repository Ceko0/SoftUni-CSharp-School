string serchingBook = Console.ReadLine();
int books = 0;
while (true)
{
    string income = Console.ReadLine();

    if (income == serchingBook)
    {
        Console.WriteLine($"You checked {books} books and found it.");
        break;
    }
    if (income == "No More Books")
    {
        Console.WriteLine("The book you search is not here!");
        Console.WriteLine($"You checked {books} books.");
        break;
    }
    books++;
}
