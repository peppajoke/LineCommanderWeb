using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LineCommander.Api.CommandWeb
{
    public class WebConsole : IConsole
    {
        private Queue<string> _incomingInputs = new Queue<string>();
        private Queue<string> _outgoingOutputs = new Queue<string>();

        private bool _waitingForInput = false;

        const int MAX_POLL_COUNT = 30;
        public async Task<ConsoleKeyInfo> ReadKey()
        {
            throw new NotImplementedException();
        }

        public async Task<string> ReadLine()
        {
            var pollCount = 0;
            Console.WriteLine("starting the polling....");
            while (_incomingInputs.Count == 0)
            {
                Console.WriteLine("Attempt");
                _waitingForInput = true;
                pollCount++;
                Thread.Sleep(2000);

                if (pollCount >= MAX_POLL_COUNT)
                {
                    Console.WriteLine("I GIVE UP");
                    throw new Exception("Command timeout.");
                }
            }
            Console.WriteLine("done trying");
            _waitingForInput = false;
            return _incomingInputs.Dequeue();
        }

        public async Task Write(string message)
        {
            _outgoingOutputs.Enqueue(message);
        }

        public async Task WriteLine(string message)
        {
            Console.WriteLine("GOT A RESPONSE IN!");
            _outgoingOutputs.Enqueue(message);
        }
        public async Task FeedInputLine(string input)
        {
            Console.WriteLine("Response!");
            _incomingInputs.Enqueue(input);
        }

        public async Task<IEnumerable<string>> FlushOutput()
        {
            var output = new List<string>();
            while (_outgoingOutputs.Count > 0) 
            {
                Console.WriteLine("Found an output message!!");
                var msg = _outgoingOutputs.Dequeue();
                output.Add(msg);
                Console.WriteLine(msg);
            }
            return output;
        }

        public bool IsWaitingForUserInput()
        {
            return _waitingForInput && _incomingInputs.Count == 0;
        }
    }
}