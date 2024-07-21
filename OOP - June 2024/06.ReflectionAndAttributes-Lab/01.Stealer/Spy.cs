using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    { 
        public string StealFieldInfo(string classOfInvestigate , params string[] nameOfFields) 
        {
            Type classType = Type.GetType(classOfInvestigate);

            FieldInfo[] classField = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            object classInstance = Activator.CreateInstance(classType, new object[] { });
            StringBuilder sb = new();
            sb.AppendLine($"Class under investigation: {classOfInvestigate}");
            foreach (FieldInfo field in classField
                         .Where(f => nameOfFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type? classType = Type.GetType(className);
            FieldInfo[] classFilds = classType.GetFields(BindingFlags.Instance | BindingFlags.Public );
            PropertyInfo[] classPublicProperties = classType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] classNonPublicProperties = classType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new();
            foreach (FieldInfo field in classFilds.Where(f => !f.IsPrivate))
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in classNonPublicProperties.Select(p => p.GetMethod).Where(g => g.IsPrivate))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in classPublicProperties.Select(p => p.SetMethod).Where(s => s.IsPublic))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string classnName)
        {
            Type classType = Type.GetType(classnName);
            MethodInfo[] methods =
                classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic );
            StringBuilder sb = new();
            sb.AppendLine($"All Private Methods of Class: {classnName}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (MethodInfo method in methods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }
    }
}
