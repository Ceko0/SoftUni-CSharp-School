namespace _02.TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());

            int[] currentState = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            bool liftIsFull =false;

            for (int i = 0; i < currentState.Length; i++)
            {
                while (true)
                {
                    if (i == currentState.Length -1 && currentState[i] == 4)
                    {
                        liftIsFull = true;
                    }
                    if (currentState[i] == 4 || peopleWaiting == 0)
                    {
                        break;
                    }
                    currentState[i]++;
                    peopleWaiting--;
                }
                
            }
            if (peopleWaiting > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
                Console.WriteLine("{0}", string.Join(" ", currentState));
            }
            else if (peopleWaiting == 0 && liftIsFull )
            {
                Console.WriteLine("{0}", string.Join(" ", currentState));
            }
            else
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine("{0}", string.Join(" ", currentState));
            }
        }
    }
}
