using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Helpers
{
    public static class FileReader
    {
        /// <summary>
        /// Stocks Vending Machine
        /// </summary>
        /// <param name="vm">Vending Machine to Stock</param>
        public static void StockVendingMachine(VendingMachine vm)
        {
            string file = "vendingmachine.csv";
            try
            {
                using(StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        vm.AddItem(line);
                    }
                }


            }
            catch(Exception e)
            {
                FileWriter.Log(e.Message);
                ConsoleHelper.Write("Error While Stocking, Some Items May Be Missing");
            }
        }


    }
}
