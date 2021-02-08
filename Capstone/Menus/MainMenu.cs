using Capstone.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Menus
{
    public static class MainMenu
    {
        public static void Open(VendingMachine vm)
        {

            //Present Main menu
            ConsoleHelper.Write("\n(1) Display Vending Machine Item");
            ConsoleHelper.Write("(2) Purchase");
            ConsoleHelper.Write("(3) Exit\n");
            //Get and capture user feedback
            string userInput = ConsoleHelper.GetUserInput("Selection?(1,2,3)");
            if (userInput == "1")
            {
                ConsoleHelper.Write(vm.GetInventory());
            }
            else if (userInput == "2")
            {
                PurchaseMenu.Open(vm);
            }
            else if (userInput =="4")
            {
                FileWriter.Write(vm.GenerateReport());
                ConsoleHelper.Write("Report Generated");
            }
            if (userInput != "3")
            {
                //recursion to stay within method "Do it again"
                Open(vm);
            }

        }
    }
}
