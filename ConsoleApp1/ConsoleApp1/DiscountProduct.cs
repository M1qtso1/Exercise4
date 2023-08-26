namespace ConsoleApp1
{// The DiscountProduct class inherits from the Product class and adds a new property Discount
    public class DiscountProduct : Product
    {
        private decimal discount;

        // The DiscountProduct class constructor takes four arguments and passes three of them to the base class Product constructor
        public DiscountProduct(string name, decimal price, int quantity, decimal discount) : base(name, price, quantity)
        {
            this.discount = discount;
        }
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        // The ToString method returns a text representation of the product with a discount
        public override string ToString()
        {
            return $"{base.ToString()} - {discount * 100}% off";
        }
    }
}
