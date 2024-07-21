using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(exitCode: 0);
            return null;
        }
    }
}
