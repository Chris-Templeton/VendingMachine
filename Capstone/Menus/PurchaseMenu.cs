using Capstone.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Menus
{
    public static class PurchaseMenu
    {
        public static void Open(VendingMachine vm)
        {


            ConsoleHelper.Write("\n(1) Feed Money");
            ConsoleHelper.Write("(2) Select Product");
            ConsoleHelper.Write("(3) Finish Transaction\n");

            ConsoleHelper.Write($"Current Money Provided: {vm.Balance:C2}\n");
            string userInput = ConsoleHelper.GetUserInput("Selection?(1,2,3)");
            if (userInput == "1")
            {
                FeedMoneyMenu.Open(vm);
            }
            else if (userInput == "2")
            {
                SelectProductMenu.Open(vm);
            }
            else if (userInput == "3")
            {
                decimal oldBalance = vm.Balance;
                ConsoleHelper.Write(vm.DispenseChange());
                FileWriter.Log($"GIVE CHANGE: {oldBalance:C2} {vm.Balance:C2}");
            }
            if (userInput != "3")
            {
                Open(vm);
            }

        }
        
    }
}
