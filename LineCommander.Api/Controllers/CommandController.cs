using System.Collections.Concurrent;
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
            var model = new StartCommandModel();
            return View(model);
        }

        public IActionResult Send(string command, string sessionId)
        {
            var session = GetSession(sessionId);
            var responses = session.SendCommand(command);
            return Json( new { messages = responses });
        }

        private CommandSession GetSession(string sessionId)
        {
            if (_activeCommandSessions.ContainsKey(sessionId))
            {
                return _activeCommandSessions[sessionId];
            }
            else
            {
                return new CommandSession();
            }
        }
    }
}