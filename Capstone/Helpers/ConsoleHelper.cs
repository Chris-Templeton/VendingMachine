using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Helpers
{
    //dont want an instance, just helping 
    public static class ConsoleHelper
    {
        //write line is same as Console.WriteLine but easier to adjust in the future
        public static void Write(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// prompts user a question and returns user answer
        /// </summary>
        /// <param name="question">Question for user</param>
        /// <returns>User Response</returns>
        public static string GetUserInput(string question)
        {
            Write(question);
            return Console.ReadLine();
        }
  
    }
}
