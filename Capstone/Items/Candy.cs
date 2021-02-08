using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Items
{
    public class Candy : AbstractItems
    {
        public Candy(string productName, decimal price, int quanity):base(productName,price,quanity)
        {

        }
        public override string Message
        {
            get
            {
                return "Munch Munch, Yum!";
            }
        }

            
    }
}
