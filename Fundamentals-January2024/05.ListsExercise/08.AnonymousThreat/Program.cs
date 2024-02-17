namespace _08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> stolenData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string income = "";
            while ((income = Console.ReadLine()) != "3:1")
            {
                List<string> commands = income
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                switch (commands[0])
                {
                    case "merge":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        startIndex = Math.Clamp(startIndex, 0, stolenData.Count - 1);
                        endIndex = Math.Clamp(endIndex, 0, stolenData.Count - 1);
                        string newLetter = "";
                        for (int i = endIndex; i >= startIndex; i--)
                        {
                            newLetter = stolenData[i] + newLetter;
                            stolenData.RemoveAt(i);
                        }
                        stolenData.Insert(startIndex, newLetter);
                        break;
                    case "divide":
                        int index = int.Parse(commands[1]);
                        int partitions = int.Parse(commands[2]);
                        string letterToSplit = stolenData[index];
                        int newPartitionSize = letterToSplit.Length / partitions;
                        List<string> newLetterToInsert = new List<string>();
                        int letterCounter = 0;

                        if (letterToSplit.Length % partitions == 0)
                        {
                            for (int i = 0; i < partitions; i++)
                            {
                                string letters = "";
                                for (int j = 0; j < newPartitionSize; j++)
                                {
                                    letters += letterToSplit[letterCounter++];
                                }

                                newLetterToInsert.Add(letters);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < partitions; i++)
                            {
                                string letters = "";
                                if (i == partitions - 1)
                                {
                                    for (int j = letterCounter; j < letterToSplit.Length; j++)
                                    {
                                        letters += letterToSplit[letterCounter++];
                                    }
                                    newLetterToInsert.Add(letters);
                                    break;
                                }
                                for (int j = 0; j < newPartitionSize; j++)
                                {

                                    letters += letterToSplit[letterCounter++];
                                }

                                newLetterToInsert.Add(letters);
                            }
                        }

                        stolenData.RemoveAt(index);
                        stolenData.InsertRange(index, newLetterToInsert);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", stolenData));
        }
    }
}
/*
Ivo Johny Tony Bony Mony
merge 0 3
merge 3 4
merge 0 3
3:1

asddsafsd 1237dsfkasd123 5444

asd dsa fsd 1237 dsfkasd 123 5444
merge 0 2
merge 1 3
3:1

abcd efgh ijkl mnop qrst uvwx yz
merge 4 10
divide 4 5
3:1

 */

