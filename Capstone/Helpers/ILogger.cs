using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Helpers
{
    public interface ILogger
    {
        /// <summary>
        /// Reads a string line from an input source
        /// </summary>
        /// <returns>String from input source.</returns>
        public string ReadLine();

        /// <summary>
        /// Asks user a question, then reads a string line from an input source.
        /// </summary>
        /// <param name="question">Question to prompt user.</param>
        /// <returns>String response from input source.</returns>
        public string ReadLine(string question);

        /// <summary>
        /// Writes a string line to some output source.
        /// </summary>
        /// <param name="message">Message to write.</param>
        public void WriteLine(string message);
    }
}
