using ConsoleApp1;
using System;
namespace ConsoleApp1
{
    public class Product
    {
        private string name;
        private decimal price;
        private int quantity;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        public Product(string name, decimal price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

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
