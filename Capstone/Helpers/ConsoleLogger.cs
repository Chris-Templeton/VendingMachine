using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Helpers
{
    public class ConsoleLogger : ILogger
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public string ReadLine(string message)
        {
            WriteLine(message);
            return ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
