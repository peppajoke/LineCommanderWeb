using System;
using System.Collections.Generic;

namespace LineCommander.Api.CommandWeb
{
    public class WebConsole : IConsole
    {
        public ConsoleKeyInfo ReadKey()
        {
            throw new NotImplementedException();
        }

        public string ReadLine()
        {
            throw new NotImplementedException();
        }

        public void Write(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string message)
        {
            throw new NotImplementedException();
        }
    }
}