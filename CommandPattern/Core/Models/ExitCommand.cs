using System;

namespace CommandPattern.Core.Models
{
    using Contracts;
    class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return null;
        }
    }
}
