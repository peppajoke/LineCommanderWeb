using System.Collections.Generic;

namespace LineCommander.Api.CommandWeb
{
    public class CommandSession
    {
        private IConsole _console;
        private Commander _commander;

        public CommandSession(IConsole console = null, Commander commander = null)
        {
            _console = console ?? new WebConsole();
            _commander = commander ?? new Commander(_console);
        }

        public IEnumerable<string> SendCommand(string messageIn)
        {
            return new List<string>() {"bye felicia"};
        }
    }
}