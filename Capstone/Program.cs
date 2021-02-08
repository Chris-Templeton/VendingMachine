using System;
using Capstone.Helpers;
using Capstone.Items;
using Capstone.Menus;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate A Vending Machine 
            VendingMachine vm = new VendingMachine(0);

            //Stock Vending Machine 
            FileReader.StockVendingMachine(vm);
            //UI, prompts user for response(menus)
            try
            {
                //MainMenu(vm);
                MainMenu.Open(vm);
            }
            catch(Exception e)
            {
                //incase you add a billion quarters or something/anything else that boom boom
                FileWriter.Log(e.Message);
                ConsoleHelper.Write("Error Occured, Closing Application. BYE BYE");
            }

        }

    }

}


