using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LineCommander.Api.Services;

namespace LineCommander.Api.Commands
{
    public class ConfigCommand : BaseCommand
    {
        


        public override string Description()
        {
            throw new System.NotImplementedException();
        }

        public override async Task<bool> Execute(IEnumerable<string> arguments)
        {
            var kvpStore = new ImmanuelStore();
            var args = arguments.ToList();
            var baseCommand = args[0].ToUpper();
            var key = args[1];
            if (baseCommand == "SET")
            {
                var value = args[2];
                await _console.WriteLine("Saving config value " + key + ": " + value);
                var success = await kvpStore.Set(key, value);
                if (success)
                {
                    await _console.WriteLine("Success!");
                }
                else
                {
                    await _console.WriteLine("Failed.");
                }
            }
            else if (baseCommand == "GET")
            {
                var value = await kvpStore.Get(key);
                await _console.WriteLine(key + ": " + value);
            }
            return true;
        }

        public override IEnumerable<string> MatchingBaseCommands()
        {
            return new List<string>() { "config" };
        }
    }
}