namespace ConsoleApp1
{
    // The Customer class represents a store customer with a Buy method that allows purchasing a product from the store
    public class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // The Buy method allows the customer to purchase a product from the store
        public void Buy(Shop shop, Product product)
        {
            if (product is DiscountProduct) // if the product is of type DiscountProduct, calculates the price after discount and subtracts it from the customer's balance
            {
                DiscountProduct dp = (DiscountProduct)product; // casting type Product to type DiscountProduct
                decimal priceAfterDiscount = dp.Price * (1 - dp.Discount);
                Console.WriteLine($"Customer {name} bought product {dp.Name} from store {shop} for {priceAfterDiscount} USD.\n_____________________");
            }
            else
            {
                Console.WriteLine($"Customer {name} bought product {product.Name} from store {shop} for {product.Price} USD.\n_____________________");
            }
        }
    }
}
