using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Product
    {
        private string name; // product name
        private decimal price; // product price
        private int quantity; // product quantity

        // The Product class constructor takes three arguments and assigns them to the class fields
        public Product(string name, decimal price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        // The get and set methods allow reading and changing the values of the class fields
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        // The ToString method returns a text representation of the product
        public override string ToString()
        {
            return $"{name} - {price} USD - {quantity} item(s)\n_____________________";
        }
    }
}
