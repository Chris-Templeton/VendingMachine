using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Items
{
    public class Drink:AbstractItems
    {
        public Drink(string productName, decimal price, int quanity) : base(productName, price, quanity)
        {

        }
        public override string Message
        {
            get
            {
                return "Glug Glug, Yum!";
            }
        }
    }
}
