using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LineCommander.Api.Commands
{
    public class TvCommand : BaseCommand
    {
        public override string Description()
        {
            return "Manipulates the TV show configuration for the media server. tv add: adds a new show to download regularly. tv remove: removes a show from being downloaded. tv all: shows all shows that will be downloaded.";
        }

        public override async Task<bool> Execute(IEnumerable<string> arguments)
        {
            if (!arguments.Any())
            {
                await _console.WriteLine("Missing modifier. tv <modifier> (add, remove, or all)");
            }
            var baseCommand = arguments.First();


            return true;
        }

        private string Add()
        {
            return "";
        }

        public override IEnumerable<string> MatchingBaseCommands()
        {
            return new List<string>() {"tv"};
        }
    }
}