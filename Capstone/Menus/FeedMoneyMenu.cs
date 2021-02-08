using Capstone.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Menus
{
    public static class FeedMoneyMenu
    {
        /// <summary>
        /// This opens FeedMoney Menu, offering These options
        /// </summary>
        /// <param name="vm">Vending Machine</param>
        public static void Open(VendingMachine vm)
        {
            ConsoleHelper.Write("\n(1) $1");
            ConsoleHelper.Write("(2) $2");
            ConsoleHelper.Write("(3) $5");
            ConsoleHelper.Write("(4) $10");
            ConsoleHelper.Write("(5) Exit\n");

            ConsoleHelper.Write($"Current Money Provided: {vm.Balance:C2}\n");
            string userInput = ConsoleHelper.GetUserInput("Selection?(1-5)");
            if (userInput == "1")
            {
                vm.Balance++;
                FileWriter.Log($"FEED MONEY: $1.00 {vm.Balance:C2}");
            }
            else if (userInput == "2")
            {
                vm.Balance += 2;
                FileWriter.Log($"FEED MONEY: $2.00 {vm.Balance:C2}");
            }
            else if (userInput == "3")
            {
                vm.Balance += 5;
                FileWriter.Log($"FEED MONEY: $5.00 {vm.Balance:C2}");
            }
            else if (userInput == "4")
            {
                vm.Balance += 10;
                FileWriter.Log($"FEED MONEY: $10.00 {vm.Balance:C2}");
            }
            if (userInput != "5")
            {
                Open(vm);
            }


        }
    }
}
