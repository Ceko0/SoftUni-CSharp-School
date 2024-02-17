namespace _10.SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> course = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            string income = "";
            while ((income = Console.ReadLine()) != "course start")
            {
                List<string> commands = income
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                switch (commands[0])
                {
                    case "Add":
                        bool isInProgram = courseCheck(course, commands[1]);
                        if (!isInProgram)
                        {
                            course.Add(commands[1]);
                        }
                        break;
                    case "Insert":
                        isInProgram = courseCheck(course, commands[1]);
                        if (!isInProgram)
                        {
                            course.Insert(int.Parse(commands[2]), commands[1]);
                        }
                        break;
                    case "Remove":
                        isInProgram = courseCheck(course, commands[1]);
                        if (isInProgram)
                        {
                            course.Remove(commands[1]);
                        }
                        break;
                    case "Swap":
                        isInProgram = courseCheck(course, commands[1]);
                        bool isInLessonSecond = courseCheck(course, commands[2]);
                        if (isInProgram && isInLessonSecond)
                        {
                            int firstIndex = course.IndexOf(commands[1]);
                            int secondIndex = course.IndexOf(commands[2]);
                            if (ExerciseCheck(course, firstIndex, commands))
                            {
                                string letterToMove = course[firstIndex];
                                string exerciseToMove = course[firstIndex + 1];

                                if (ExerciseCheck(course, secondIndex, commands))                      
                                {                                                                     
                                    course.Insert(firstIndex, course[secondIndex]);                   
                                    course.Insert(firstIndex+1 , course[secondIndex +1]);       
                                    course.RemoveAt(firstIndex+2);                              
                                    course.RemoveAt(firstIndex+2);                              
                                    course.Insert(secondIndex, letterToMove);                         
                                    course.Insert(secondIndex + 1, exerciseToMove);             
                                    course.RemoveAt(secondIndex + 2);                           
                                    course.RemoveAt(secondIndex + 2);                           
                                }
                                else
                                {
                                    course.Insert(firstIndex, course[secondIndex]);
                                    course.RemoveAt(firstIndex + 1);
                                    course.RemoveAt(firstIndex + 1);
                                    course.Insert(secondIndex -1, letterToMove);
                                    course.Insert(secondIndex, exerciseToMove);
                                    course.RemoveAt(secondIndex + 2);
                                }
                            }
                            else
                            {
                                string letterToMove = course[firstIndex];
                                if (ExerciseCheck(course, secondIndex, commands))
                                {
                                    course.Insert(firstIndex, course[secondIndex]);
                                    course.Insert(firstIndex + 1, course[secondIndex + 2]);
                                    course.RemoveAt(firstIndex + 2);
                                    course.Insert(secondIndex + 1, letterToMove);
                                    course.RemoveAt(secondIndex + 2);
                                    course.RemoveAt(secondIndex + 2);
                                }
                                else
                                {
                                    course.Insert(firstIndex, course[secondIndex]);
                                    course.RemoveAt(firstIndex + 1);
                                    course.Insert(secondIndex, letterToMove);
                                    course.RemoveAt(secondIndex + 1);
                                }
                            }
                        }
                        
                        break;
                    case "Exercise":
                        isInProgram = courseCheck(course, commands[1]);
                        if (isInProgram)
                        {
                            int lessonIndex = course.IndexOf(commands[1]);
                            if (lessonIndex + 1 >= 0 && lessonIndex + 1 < course.Count)
                            {
                                if (!ExerciseCheck(course, lessonIndex, commands))
                                {
                                    course.Insert(lessonIndex + 1, $"{commands[1]}-Exercise");
                                }
                            }
                            else
                            {
                                course.Add($"{commands[1]}-Exercise");
                            }

                        }
                        else
                        {
                            course.Add(commands[1]);
                            course.Add($"{commands[1]}-Exercise");
                        }
                        break;
                }
            }
            int positionCounter = 1;
            for (int i = 0; i < course.Count; i++)
            {
                Console.WriteLine($"{positionCounter++}.{course[i]}");
            }
        }

        private static bool ExerciseCheck(List<string> course, int lessonIndex, List<string> commands)
        {
            if (lessonIndex + 1 >= 0 && lessonIndex + 1 < course.Count)
            {
                return course[lessonIndex + 1] == $"{course[lessonIndex]}-Exercise";
            }
            return false;
        }

        private static bool courseCheck(List<string> course, string command)
        {
           return course.Contains(command);
        }
    }
}
/*
Data Types, Objects, Lists
Add:Databases
Insert:Arrays:0
Remove:Lists
course start

Arrays, Lists, Methods
Swap:Arrays:Methods
Exercise:Databases
Swap:Lists:Databases
Insert:Arrays:0
course start
*/