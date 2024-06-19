namespace _01.PiePursuit
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Queue<int> piePiecesCanEat = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> piePieces = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while(piePieces.Count > 0 && piePiecesCanEat.Count > 0) 
            {
                int canEat = piePiecesCanEat.Dequeue();
                int pieces = piePieces.Pop();
                if (canEat > pieces)
                {
                    piePiecesCanEat.Enqueue(canEat - pieces);
                }
                else if (canEat < pieces)
                {
                    piePieces.Push(pieces - canEat);
                }
                else continue;
            }
            if ( piePieces.Count == 0 && piePiecesCanEat.Count == 0)
            {
                Console.WriteLine("We have a champion!");
            }
            else if (piePieces.Count == 0)
            {
                Console.WriteLine("We will have to wait for more pies to be baked!");
                Console.Write("Contestants left: ");
                Console.Write(string.Join(" ",piePiecesCanEat));
            }
            else
            {
                Console.WriteLine("Our contestants need to rest!");
                Console.Write("Pies left: ");
                Console.Write(string.Join(" ",piePieces));
            }
        }
    }
}
