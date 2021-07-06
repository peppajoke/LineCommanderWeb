using System.Collections.Generic;
using System.Threading.Tasks;
using LineCommander;

namespace LineCommander.Api.Commands
{
    public class ConversationCommand : BaseCommand
    {
        public override string Description()
        {
            return "UR EMBARASSING ME";
        }

        public override async Task<bool> Execute(IEnumerable<string> arguments)
        {
            await _console.WriteLine("hello doggy.");
            var howTheyAre = await InputText("how are you today?");
            await _console.WriteLine("glad to her that you are " + howTheyAre);
            return true;
        }

        public override IEnumerable<string> MatchingBaseCommands()
        {
            return new List<string>() {"hello"};
        }
    }
}