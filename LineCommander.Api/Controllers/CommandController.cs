using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LineCommander.Api.Commands;
using LineCommander.Api.CommandWeb;
using LineCommander.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LineCommander.Api.Controllers
{
    public class CommandController : Controller
    {
        private static ConcurrentDictionary<string, CommandSession> _activeCommandSessions = new ConcurrentDictionary<string, CommandSession>();

        public IActionResult Start()
        {
            // todo: create session here
            var model = new StartCommandModel();
            return View(model);
        }

        public async Task<IActionResult> Send(string command, string sessionId)
        {
            var session = GetSession(sessionId);
            await session.SendCommand(command);
            var messages = await session.FlushOutput();
            // todo put polling boolean here
            return Ok();
        }

        public async Task<IActionResult> PollForMessages(string sessionId)
        {
            Console.WriteLine("polling for messages");
            var session = GetSession(sessionId);
            var messages = await session.FlushOutput();
            if (messages.Any())
            {
                Console.WriteLine("found message!!");
            }
            return Json( new { messages = messages } );
        }

        private CommandSession GetSession(string sessionId)
        {
            if (_activeCommandSessions.ContainsKey(sessionId))
            {
                return _activeCommandSessions[sessionId];
            }
            var session = new CommandSession();
            session.AddSupportedCommands(new List<BaseCommand>() { new ConversationCommand() });
            _activeCommandSessions.TryAdd(sessionId, session);
            return session;
        }
    }
}