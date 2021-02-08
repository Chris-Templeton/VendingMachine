using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Items
{
    public abstract class AbstractItems
    {
        public decimal Price { get; }
        public string ProductName { get; }
        public abstract string Message { get; }
        public int InitialQuantity { get;}
        public int Quantity { get; set; }

        public AbstractItems(string productName, decimal price, int quantity)
        {
            InitialQuantity = quantity;
            Price = price;
            ProductName = productName;
            Quantity = quantity; 
        }
        public override string ToString()
        {
            string quantity = Quantity.ToString();
            if(Quantity==0)
            {
                quantity = "SOLD OUT";
            }
            return String.Format("{0,-18}  {2,-6}  {1,-6}", ProductName, $"(QTY: {quantity})", $"{Price:C2}");
        }

    }
}
