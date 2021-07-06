using System.Collections.Generic;
using System.Threading.Tasks;

namespace LineCommander.Api.CommandWeb
{
    public class CommandSession
    {
        private WebConsole _console;
        private Commander _commander;

        public CommandSession(WebConsole console = null, Commander commander = null)
        {
            _console = console ?? new WebConsole();
            _commander = commander ?? new Commander(_console);
        }

        public async Task SendCommand(string messageIn)
        {
            if (_console.IsWaitingForUserInput())
            {
                await _console.FeedInputLine(messageIn);
            }
            else
            {
                await _commander.SendCommandInput(messageIn);
            }
        }

        public async Task<IEnumerable<string>> FlushOutput()
        {
            return await _console.FlushOutput();
        }

        public void AddSupportedCommands(IEnumerable<BaseCommand> commands)
        {
            _commander.AddCommands(commands);
        }
    }
}