using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Items
{
    public class Chip:AbstractItems
    {
        public Chip(string productName, decimal price, int quanity) : base(productName, price, quanity)
        {

        }
        public override string Message
        {
            get
            {
                return "Crunch Crunch, Yum!";
            }
        }
    }
}
