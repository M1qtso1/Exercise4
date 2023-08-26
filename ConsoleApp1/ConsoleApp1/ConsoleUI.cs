namespace ConsoleApp1
{
    // The ConsoleUI class represents a user interface based on a console
    public class ConsoleUI
    {
        private Shop shop;

        public ConsoleUI(Shop shop)
        {
            this.shop = shop;
        }

        public Shop Shop
        {
            get { return shop; }
            set { shop = value; }
        }

        // The ShowMenu method displays the main menu of the application and allows the user to choose an option
        public void ShowMenu()
        {
            bool exit = false; // variable controlling the main loop of the application
            while (!exit)
            {
                Console.WriteLine("Oleksandr Denysiuk's shop =)\n_____________________");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add a product to the store");
                Console.WriteLine("2. Display a list of products in the store");
                Console.WriteLine("3. Sell a product to a customer");
                Console.WriteLine("4. Save a list of products to a file");
                Console.WriteLine("5. Load a list of products from a file");
                Console.WriteLine("0. Exit from application\n_____________________");
                string choiceAsString = Console.ReadLine();
                MainMenuChoices choice = (MainMenuChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainMenuChoices.Add:
                        AddProduct();
                        break;
                    case MainMenuChoices.Show:
                        ShowProducts();
                        break;
                    case MainMenuChoices.Sell:
                        SellProduct();
                        break;
                    case MainMenuChoices.Save:
                        SaveProducts();
                        break;
                    case MainMenuChoices.Load:
                        LoadProducts();
                        break;
                    case MainMenuChoices.Exit:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.\n_____________________");
                        break;
                }
            }
        }

        // The AddProduct method allows user to add a product to store, asking for its properties and creating appropriate object of Product or DiscountProduct class
        private void AddProduct()
        {
            Console.WriteLine("Adding product to store.");
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You did not enter anything. Please try again.");
                Console.Write("Enter product name: ");
                name = Console.ReadLine();
            }

            Console.Write("Enter product price: ");
            string inputPrice = Console.ReadLine();
            decimal price;
            bool resultPrice = decimal.TryParse(inputPrice, out price);
            while (!resultPrice)
            {
                Console.WriteLine("You did not enter a valid number. Please try again.");
                Console.Write("Enter product price: ");
                inputPrice = Console.ReadLine();
                resultPrice = decimal.TryParse(inputPrice, out price);
            }

            Console.Write("Enter product quantity: ");
            string inputQuantity = Console.ReadLine();
            int quantity;
            bool resultQuantity = int.TryParse(inputQuantity, out quantity);
            while (!resultQuantity)
            {
                Console.WriteLine("You did not enter a valid number. Please try again.");
                Console.Write("Enter product quantity: ");
                inputQuantity = Console.ReadLine();
                resultQuantity = int.TryParse(inputQuantity, out quantity);
            }

            Console.Write("If product has discount, type 'Y', if not, leave the field empty: ");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y") // if answer is Y or y, it means that product has discount and object of DiscountProduct class should be created
            {
                Console.Write("Enter discount amount (e.g. 0,1 means 10%): ");
                string inputDiscount = Console.ReadLine();
                decimal discount;
                bool resultDiscount = decimal.TryParse(inputDiscount, out discount);
                while (!resultDiscount)
                {
                    Console.WriteLine("You did not enter a valid number. Please try again.");
                    Console.Write("Enter discount amount (e.g. 0,1 means 10%): ");
                    inputDiscount = Console.ReadLine();
                    resultDiscount = decimal.TryParse(inputDiscount, out discount);
                }

                DiscountProduct dp = new DiscountProduct(name, price, quantity, discount); // creating object of DiscountProduct class with given properties
                shop.AddProduct(dp); // adding object to list of products in store
            }
            else
            {
                Product p = new Product(name, price, quantity); // creating object of Product class
                shop.AddProduct(p); // adding object to list of products in store
            }
            Console.WriteLine("Product has been added to store.\n_____________________");
        }

        private void ShowProducts()
        {
            Console.WriteLine("Displaying list of products in store.");
            shop.ShowProducts();
        }
        // The SellProduct method allows the user to sell a product to a customer
        private void SellProduct()
        {
            Console.WriteLine("Selling product to customer.");
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Product product = FindProductByName(name); // finding product with given name on list of products in store using FindProductByName method
            if (product != null)
            {
                Console.Write("Enter customer name: ");
                string customerName = Console.ReadLine();
                Customer customer = new Customer(customerName); // creating object of Customer class with given name
                shop.SellProduct(product, customer);
            }
            else
            {
                Console.WriteLine($"There is no such product in store.\n_____________________");
            }
        }

        // The SaveProducts method allows the user to save the list of products to a JSON file
        private void SaveProducts()
        {
            Console.WriteLine("Saving list of products to a file.");
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();
            shop.SaveProducts(fileName);
            Console.WriteLine("List of products has been saved to a file.\n_____________________");
        }

        // The LoadProducts method allows the user to load the list of products from a JSON file, asking for the file name and calling the LoadProducts method of the Shop class
        private void LoadProducts()
        {
            Console.WriteLine("Loading list of products from a file.");
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();
            shop.LoadProducts(fileName);
            Console.WriteLine("List of products has been loaded from a file.\n_____________________");
        }
        // The FindProductByName method searches for a product with a given name on the list of products in the store and returns it or null if not found
        private Product FindProductByName(string name)
        {
            foreach (Product product in shop.Products) // going through the list of products in the store
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
