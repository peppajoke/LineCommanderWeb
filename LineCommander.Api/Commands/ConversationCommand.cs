using System.Collections.Generic;
using System.Threading.Tasks;
using KVaas.Net;
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
            var token = await KVaaSClient.NewKey("jack_bauerle_test");


            await _console.WriteLine("hello doggy.");
            var howTheyAre = await InputText("how are you today?");

            var setValueResult = await KVaaSClient.PutValue(token, "jack_bauerle_test", howTheyAre);

            var howReallyTheyAre = await KVaaSClient.GetValue(token, "jack_bauerle_test");
            await _console.WriteLine("glad to hear that you are " + howReallyTheyAre);
            return true;
        }

        public override IEnumerable<string> MatchingBaseCommands()
        {
            return new List<string>() {"hello"};
        }
    }
}