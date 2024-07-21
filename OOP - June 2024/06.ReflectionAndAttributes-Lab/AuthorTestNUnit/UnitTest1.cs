using System;
using NUnit.Framework;
using System.Reflection;
using System.Linq;

[TestFixture]
public class T001TestClassExists
{
    private static readonly Assembly ProjectAssembly = Assembly.Load("AuthorProblem");

    private Type[] classes =
    {
        GetType("AuthorAttribute")
    };

    [Test]
    public void AssertExistingClasses()
    {
        foreach (var className in classes)
        {
            AssertClassExists(className);
        }
    }

    private void AssertClassExists(Type className)
    {
        Assert.IsNotNull(className);
    }

    private static Type GetType(string name)
    {
        var type = ProjectAssembly
            .GetTypes()
            .Where(x => !x.IsInterface)
            .FirstOrDefault(t => t.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        return type;
    }
}