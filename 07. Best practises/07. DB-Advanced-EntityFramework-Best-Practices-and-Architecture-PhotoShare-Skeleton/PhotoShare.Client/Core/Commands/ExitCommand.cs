using System;

namespace PhotoShare.Client.Core.Commands
{
    public class ExitCommand : Command
    {
        

        public ExitCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return "Bye-bye";
        }
    }
}
