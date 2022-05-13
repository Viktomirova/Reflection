using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Models
{
    using System;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split();

            string commandName = tokens[0];
            string[] commandArgs = tokens[1..];

            //ICommand command = default;
            //if (commandName == "Hello")
            //{
            //    command = new HelloCommand();
            //}
            //else if (commandName == "Exit")
            //{
            //    command = new ExitCommand();
            //}

            Type commandType = Assembly.GetCallingAssembly()
                                   .GetTypes()
                                   .FirstOrDefault(x => x.Name == $"{commandName}Command");

            ICommand command = (ICommand)Activator.CreateInstance(commandType);

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
