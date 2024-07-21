using System;
using System.Data;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] info = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = info[0];
            string[] passthroughArgs = info[1..];

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(x => typeof(ICommand).IsAssignableFrom(x) && x.Name.StartsWith(commandName));
            if (commandType is null)
                throw new InvalidOperationException($"Command\"{commandName}\" was not found");

            ICommand commandInstance = Activator.CreateInstance(commandType) as ICommand;
            return commandInstance.Execute(passthroughArgs);
        }
    }
}
