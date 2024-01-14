//1.dog->mammal
//2.crocodile, tortoise, snake -> reptile
//3.	others -> unknown
string animal = Console.ReadLine();
if (animal == "dog")
{
    Console.WriteLine("mammal");
}
else if (animal == "crocodile" || animal == "tortoise" || animal == "snake")
{
    Console.WriteLine("reptile");
}
else
{
    Console.WriteLine("unknown");
}