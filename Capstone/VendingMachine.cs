using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Items;
namespace Capstone
{
    public class VendingMachine
    {
        public Dictionary<string,AbstractItems> Inventory { get; private set; }
        public decimal Balance { get; set; }
        
        public VendingMachine(decimal balance)
        {
            Balance = balance;
            Inventory = new Dictionary<string, AbstractItems>();

        }
        public void AddItem(string item)
        {
            string[] itemArray = item.Split("|");
            AbstractItems itemToAdd = null;
            decimal price = decimal.Parse(itemArray[2]);
            string itemName = itemArray[1];
            if (itemArray[3]=="Candy")
            {
                itemToAdd = new Candy(itemName, price, 5);
               
            }
            else if (itemArray[3] == "Gum")
            {
                itemToAdd = new Gum(itemName, price, 5);
            }
            else if (itemArray[3] == "Chip")
            {
                itemToAdd = new Chip(itemName, price, 5);
            }
            else if (itemArray[3] == "Drink")
            {
                itemToAdd = new Drink(itemName, price, 5);
            }
            Inventory.Add(itemArray[0], itemToAdd);
        }
        public string GetInventory()
        {
            string inventory = "";
            foreach (string itemKey in Inventory.Keys)
            {
                inventory += $"{itemKey}. {Inventory[itemKey]}\n";
            }

            return inventory; 
        }
        public bool Contains(string productKey)
        {
            return Inventory.ContainsKey(productKey);
        }
        public bool IsNotSoldOut(string productKey)
        {
            return Inventory[productKey].Quantity > 0;
        }
        public bool CanBuy(string productKey)
        {
            return Balance >= Inventory[productKey].Price;
        }
        public void Purchase(string productKey)
        {
            Balance-= Inventory[productKey].Price;
            Inventory[productKey].Quantity--;
        }
        public string DispenseChange()
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;
            while(Balance>0)
            {
                if(Balance>=.25M)
                {
                    quarters++;
                    Balance -= .25M;
                }
                else if(Balance>=.1M)
                {
                    dimes++;
                    Balance -= .10M;
                }
                else if (Balance >=.05M)
                {
                    nickels++;
                    Balance -= .05M;
                }
                else
                {
                    pennies++;
                    Balance -= .01M;
                }

            }

            return $"Dispensed Change Quarters:{quarters} Dimes:{dimes} Nickels:{nickels} Pennies:{pennies}";
        }
        public string GenerateReport()
        {
            decimal totalSales = 0;
            string output = "";
            foreach (AbstractItems item in Inventory.Values)
            {
                int soldItems = item.InitialQuantity - item.Quantity;
                output += $"{item.ProductName}|{soldItems}\n";
                totalSales += soldItems * item.Price;
                
            }
            output += $"\n{totalSales:C2}";
            return output;
        }

    }
}
