using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Items
{
    public class Gum:AbstractItems
    {
        public Gum(string productName, decimal price, int quanity) : base(productName, price, quanity)
        {

        }
        public override string Message
        {
            get
            {
                return "Chew Chew, Yum!";
            }
        }
    }
}
