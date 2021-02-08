using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Helpers
{
    public static class FileWriter
    {
        public static void Log(string message)
        {
            string file = "logs/Log.txt";
            //checks and creates folders
            if (!Directory.Exists("logs"))
            {
                Directory.CreateDirectory("logs");
            }

            try
            {
                using(StreamWriter sw = new StreamWriter(file,true))
                {
                    DateTime date = DateTime.Now;
                    sw.WriteLine($"{date:MM/dd/yyyy hh:mm:ss tt} {message}");
                }

            }
            catch(Exception e)
            {

                //Note no file to log issue, user wont care if log exists or not
            }
            
        }
        public static void Write(string message)
        {
            string file = $"reports/Report-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.txt";
            //checks and creates folders
            if (!Directory.Exists("reports"))
            {
                Directory.CreateDirectory("reports");
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(file, true))
                {

                    sw.WriteLine(message);
                }

            }
            catch (Exception e)
            {

                 FileWriter.Log(e.Message);
                ConsoleHelper.Write("Issue Writing To File");
            }
        }
    }
}
