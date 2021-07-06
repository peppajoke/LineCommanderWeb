using System.Collections.Generic;
using LineCommander;

namespace LineCommander.Api.Commands
{
    public class ConversationCommand : BaseCommand
    {
        public override string Description()
        {
            return "UR EMBARASSING ME";
        }

        public override bool Execute(IEnumerable<string> arguments)
        {
            _console.WriteLine("hello doggy.");
            var howTheyAre = _console.InputText("how are you today?");
            _console.WriteLine("glad to her that you are " + howTheyAre);
            return false;
        }

        public override IEnumerable<string> MatchingBaseCommands()
        {
            return new List<string>() {"hello"};
        }
    }
}