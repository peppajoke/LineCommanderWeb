using System.Collections.Generic;
using System.Threading;
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
                // initialize the command in the background, so it can stay alive after the request
                new Thread(() => _commander.SendCommandInput(messageIn)) { IsBackground = true }.Start();
            }
        }

        public async Task<IEnumerable<string>> FlushOutput()
        {
            var output = await _console.FlushOutput();
            if (!_console.IsWaitingForUserInput())
            {
                
            }
            return output;
        }

        public void AddSupportedCommands(IEnumerable<BaseCommand> commands)
        {
            _commander.AddCommands(commands);
        }
    }
}