namespace _7.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int triangleHigh = int.Parse(Console.ReadLine());

            ulong[][] jaggedArr = new ulong[triangleHigh][];
            
            for (int i = 0; i < triangleHigh; i++)
            {
                jaggedArr[i] = new ulong[i + 1];
                for (int j = 0; j < i+1; j++)
                {
                    
                    if (j == 0) jaggedArr[i][j] = 1;
                    else if (j == i) jaggedArr[i][j] = 1;
                    else if(j < i + 1)
                    {
                        jaggedArr[i][j] = jaggedArr[i-1][j-1] + jaggedArr[i - 1][j];
                    }
                }
            }

            for (int i = 0; i < triangleHigh; i++)
            {
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.Write($"{jaggedArr[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
