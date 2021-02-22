using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace VendingMachine.Helpers
{
    public class FileLogger : ILogger
    {
        private string _filePath;
        private bool _useDate;
        private ILogger logFile;
        private StreamReader sr;
        private StreamWriter sw;


        /// <summary>
        /// True if StreamReader has not yet been opened OR is at end of stream, otherwise false.
        /// </summary>
        public bool EndOfStream
        {
            get
            {
                return !(sr is null) && sr.EndOfStream;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">Path to file location.</param>
        /// <param name="useDate">Whether or not to include the date/time when writing to files.</param>
        public FileLogger(string filePath, bool useDate = false, ILogger logFile = null)
        {
            _filePath = filePath;
            _useDate = useDate;
            this.logFile = logFile;

            if (!Directory.Exists(Path.GetDirectoryName(filePath))) 
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
        }

        public string? ReadLine()
        {
            string output = null;
            try
            {
                if (sr is null)
                {
                    sr = new StreamReader(_filePath);
                }
                output = sr.ReadLine();
            }
            catch (Exception e)
            {
                if (!(logFile is null))
                {
                    logFile.WriteLine(e.Message);
                }
                else
                {
                    Console.WriteLine(e.Message);
                }
            }

            return output;
        }

        public string ReadLine(string question)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string message)
        {
            string dateTime = (_useDate) ? $"<{DateTime.Now:yyyy/MM/dd HH:mm:ss}> " : "";

            if (sw is null)
            {
                sw = new StreamWriter(_filePath);
            }

            sw.WriteLine(dateTime + message);
        }
    }
}
