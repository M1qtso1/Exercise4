using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // The Customer class represents a store customer with a Buy method that allows purchasing a product from the store
    public class Customer
    {
        // The class field is private and accessible only through the get and set method
        private string name; // customer name

        // The Customer class constructor takes one argument and assigns it to the class field
        public Customer(string name)
        {
            this.name = name;
        }

        // The get and set method allows reading and changing the value of the class field
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // The Buy method allows the customer to purchase a product from the store, checking whether it is a regular product or a product with a discount and applying the appropriate price
        public void Buy(Shop shop, Product product)
        {
            if (product is DiscountProduct) // if the product is of type DiscountProduct, calculates the price after discount and subtracts it from the customer's balance
            {
                DiscountProduct dp = (DiscountProduct)product; // casting type Product to type DiscountProduct
                decimal priceAfterDiscount = dp.Price * (1 - dp.Discount); // calculating the price after discount
                Console.WriteLine($"Customer {name} bought product {dp.Name} from store {shop} for {priceAfterDiscount} USD.\n_____________________");
            }
            else // if the product is of type Product, uses the base price and subtracts it from the customer's balance
            {
                Console.WriteLine($"Customer {name} bought product {product.Name} from store {shop} for {product.Price} USD.\n_____________________");
            }
        }
    }
}
