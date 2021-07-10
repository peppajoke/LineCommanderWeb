using System.Collections.Generic;
using System.Threading.Tasks;

namespace LineCommander.Api.Commands
{
    public class ChatCommand : BaseCommand
    {
        public override string Description()
        {
            return "Disables commands, initiates a chat with LineCommander's AI.";
        }

        public override async Task<bool> Execute(IEnumerable<string> arguments)
        {
            var name = await InputText("Hey there. What is your name?");
            await _console.WriteLine("It's nice to meet you, " + name);

            var converse = true;
            var aiResponse = "What did you want to talk about today?";
            while (converse)
            {
                var userMessage = await InputText(aiResponse);
                aiResponse = GetResponse(name, userMessage);
                if (userMessage.ToUpper() == "BYE" || userMessage.ToUpper() == "GOODBYE")
                {
                    converse = false;
                }
            }
            await _console.WriteLine("See you later!");
            return false;
        }

        private string GetResponse(string userName, string message)
        {
            // determine message sentiment
            // profanity?
            

            return "Ok just fuck off";
        }

        public override IEnumerable<string> MatchingBaseCommands()
        {
            return new List<string> { "chat", "c" };
        }
    }
}