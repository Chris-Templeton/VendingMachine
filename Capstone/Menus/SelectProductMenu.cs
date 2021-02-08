using Capstone.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Menus
{
    public static class SelectProductMenu
    {
        public static void Open(VendingMachine vm)
        {
            ConsoleHelper.Write(vm.GetInventory());
            ConsoleHelper.Write($"Current Money Provided: {vm.Balance:C2}\n");
            string userInput = ConsoleHelper.GetUserInput("Select a Product (ie A1)");
            if (vm.Contains(userInput))
            {
                if (vm.IsNotSoldOut(userInput))
                {
                    if (vm.CanBuy(userInput))
                    {
                        decimal oldBalance = vm.Balance;

                        vm.Purchase(userInput);
                        ConsoleHelper.Write($"\n{vm.Inventory[userInput].ProductName} Cost:{vm.Inventory[userInput].Price:C2} Balance:{vm.Balance:C2}");
                        ConsoleHelper.Write(vm.Inventory[userInput].Message);
                        FileWriter.Log($"{vm.Inventory[userInput].ProductName} {userInput} {oldBalance:C2} {vm.Balance:C2}");
                    }
                    else
                    {
                        ConsoleHelper.Write("Not enough funds");
                    }
                }
                else
                {
                    ConsoleHelper.Write("SOLD OUT");
                }                    
            }
            else
            {
                ConsoleHelper.Write("Katie you know that's not a value lol");
            }
        }
    }
}
