using System.Reflection;

namespace AuthorProblem
{
    internal class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance  | BindingFlags.Static | BindingFlags.Public);

            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    
                }
            }
        }
    }
}
