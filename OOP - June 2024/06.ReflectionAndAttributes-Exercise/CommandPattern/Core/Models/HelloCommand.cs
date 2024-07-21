using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            if (args is null) 
                throw new ArgumentNullException(nameof(args));
            if (args.Length != 1) 
                throw new InvalidOperationException("Hello commands requires a single argument");

            return $"Hello, {args[0]}";
        }
    }
}
