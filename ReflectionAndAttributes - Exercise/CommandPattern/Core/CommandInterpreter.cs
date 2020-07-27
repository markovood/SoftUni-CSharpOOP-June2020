using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public string Read(string args)
        {
            string[] inputArgs = args.Split();

            string commandName = inputArgs[0];
            string commandTypeName = commandName + COMMAND_POSTFIX;

            Type commandType = Assembly
                                .GetCallingAssembly()
                                .GetTypes()
                                .Where(t => t.GetInterfaces()
                                                        .Any(i => i.Name == nameof(ICommand))
                                        )
                                .FirstOrDefault(t => t.Name == commandTypeName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            string[] commandArgs = inputArgs.Skip(1).ToArray();
            string result = command.Execute(commandArgs);

            return result;
        }
    }
}