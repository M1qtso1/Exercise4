using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // The ConsoleUI class represents a user interface based on a console
    public class ConsoleUI
    {
        // The class field is private and accessible only through the get and set method
        private Shop shop; // store that cooperates with the user interface

        // The ConsoleUI class constructor takes one argument and assigns it to the class field
        public ConsoleUI(Shop shop)
        {
            this.shop = shop;
        }

        // The get and set method allows reading and changing the value of the class field
        public Shop Shop
        {
            get { return shop; }
            set { shop = value; }
        }

        // The ShowMenu method displays the main menu of the application and allows the user to choose an option
        public void ShowMenu()
        {
            bool exit = false; // variable controlling the main loop of the application
            while (!exit) // main loop of the application runs until user chooses exit option
            {
                Console.WriteLine("Oleksandr Denysiuk's shop =)\n_____________________");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add a product to the store");
                Console.WriteLine("2. Display a list of products in the store");
                Console.WriteLine("3. Sell a product to a customer");
                Console.WriteLine("4. Save a list of products to a file");
                Console.WriteLine("5. Load a list of products from a file");
                Console.WriteLine("0. Exit from application\n_____________________");
                string choice = Console.ReadLine(); // reading user's choice
                switch (choice) // performing appropriate action depending on user's choice
                {
                    case "1":
                        AddProduct(); // calling AddProduct method
                        break;
                    case "2":
                        ShowProducts(); // calling ShowProducts method
                        break;
                    case "3":
                        SellProduct(); // calling SellProduct method
                        break;
                    case "4":
                        SaveProducts(); // calling SaveProducts method
                        break;
                    case "5":
                        LoadProducts(); // calling LoadProducts method
                        break;
                    case "0":
                        exit = true; // setting exit variable to true, which will end main loop of application
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.\n_____________________"); // displaying error message if user enters incorrect option
                        break;
                }
            }
        }

        // The AddProduct method allows user to add a product to store, asking for its properties and creating appropriate object of Product or DiscountProduct class
        public void AddProduct()
        {
            Console.WriteLine("Adding product to store.");
            Console.Write("Enter product name: ");
            string name = Console.ReadLine(); // reading product name from user
            while (string.IsNullOrEmpty(name)) // while the input is empty
            {
                Console.WriteLine("You did not enter anything. Please try again.");
                Console.Write("Enter product name: ");
                name = Console.ReadLine(); // reading product name from user again
            }
            // if the input is not empty, the loop will end and program will go for the next step
            Console.Write("Enter product price: ");
            string inputPrice = Console.ReadLine(); // reading product price from user as a string
            decimal price;
            bool resultPrice = decimal.TryParse(inputPrice, out price); // trying to parse the input to a decimal type
            while (!resultPrice) // while the parsing failed
            {
                Console.WriteLine("You did not enter a valid number. Please try again.");
                Console.Write("Enter product price: ");
                inputPrice = Console.ReadLine(); // reading product price from user as a string again
                resultPrice = decimal.TryParse(inputPrice, out price); // trying to parse the input to a decimal type again
            }
            // if the parsing was successful, the loop will end and program will go for the next step
            Console.Write("Enter product quantity: ");
            string inputQuantity = Console.ReadLine(); // reading product quantity from user as a string
            int quantity;
            bool resultQuantity = int.TryParse(inputQuantity, out quantity); // trying to parse the input to an int type
            while (!resultQuantity) // while the parsing failed
            {
                Console.WriteLine("You did not enter a valid number. Please try again.");
                Console.Write("Enter product quantity: ");
                inputQuantity = Console.ReadLine(); // reading product quantity from user as a string again
                resultQuantity = int.TryParse(inputQuantity, out quantity); // trying to parse the input to an int type again
            }
            // if the parsing was successful, the loop will end and program will go for the next step
            Console.Write("If product has discount, type 'Y', if not, leave the field empty: ");
            string answer = Console.ReadLine(); // reading answer from user, whether product has discount
            if (answer == "Y" || answer == "y") // if answer is Y or y, it means that product has discount and object of DiscountProduct class should be created
            {
                Console.Write("Enter discount amount (e.g. 0,1 means 10%): ");
                string inputDiscount = Console.ReadLine(); // reading product discount from user as a string
                decimal discount;
                bool resultDiscount = decimal.TryParse(inputDiscount, out discount); // trying to parse the input to a decimal type
                while (!resultDiscount) // while the parsing failed
                {
                    Console.WriteLine("You did not enter a valid number. Please try again.");
                    Console.Write("Enter discount amount (e.g. 0,1 means 10%): ");
                    inputDiscount = Console.ReadLine(); // reading product discount from user as a string again
                    resultDiscount = decimal.TryParse(inputDiscount, out discount); // trying to parse the input to a decimal type again
                }
                // if the parsing was successful, the loop will end and program will go for the next step
                DiscountProduct dp = new DiscountProduct(name, price, quantity, discount); // creating object of DiscountProduct class with given properties
                shop.AddProduct(dp); // adding object to list of products in store
            }
            else // if answer is not Y or y, it means that product does not have discount and object of Product class should be created
            {
                Product p = new Product(name, price, quantity); // creating object of Product class with given properties
                shop.AddProduct(p); // adding object to list of products in store
            }
            Console.WriteLine("Product has been added to store.\n_____________________"); // displaying information about success
        }

        // The ShowProducts method calls the ShowProducts method of the Shop class, which displays information about all products in the store
        public void ShowProducts()
        {
            Console.WriteLine("Displaying list of products in store.");
            shop.ShowProducts(); // calling ShowProducts method of the Shop class
        }
        // The SellProduct method allows the user to sell a product to a customer, asking for the product name and customer name and calling the SellProduct method of the Shop class
        public void SellProduct()
        {
            Console.WriteLine("Selling product to customer.");
            Console.Write("Enter product name: ");
            string name = Console.ReadLine(); // reading product name from user
            Product product = FindProductByName(name); // finding product with given name on list of products in store using FindProductByName method
            if (product != null) // if product with given name was found
            {
                Console.Write("Enter customer name: ");
                string customerName = Console.ReadLine(); // reading customer name from user
                Customer customer = new Customer(customerName); // creating object of Customer class with given name
                shop.SellProduct(product, customer); // calling SellProduct method of Shop class with given arguments
            }
            else // if product with given name was not found, displaying error message
            {
                Console.WriteLine($"There is no such product in store.\n_____________________");
            }
        }

        // The SaveProducts method allows the user to save the list of products to a JSON file, asking for the file name and calling the SaveProducts method of the Shop class
        public void SaveProducts()
        {
            Console.WriteLine("Saving list of products to a file.");
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine(); // reading file name from user
            shop.SaveProducts(fileName); // calling SaveProducts method of Shop class with given argument
            Console.WriteLine("List of products has been saved to a file.\n_____________________"); // displaying information about success
        }

        // The LoadProducts method allows the user to load the list of products from a JSON file, asking for the file name and calling the LoadProducts method of the Shop class
        public void LoadProducts()
        {
            Console.WriteLine("Loading list of products from a file.");
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine(); // reading file name from user
            shop.LoadProducts(fileName); // calling LoadProducts method of Shop class with given argument
            Console.WriteLine("List of products has been loaded from a file.\n_____________________"); // displaying information about success
        }
        // The FindProductByName method searches for a product with a given name on the list of products in the store and returns it or null if not found
        public Product FindProductByName(string name)
        {
            foreach (Product product in shop.Products) // going through the list of products in the store
            {
                if (product.Name == name) // if the product name is equal to the given name
                {
                    return product; // returns the product
                }
            }
            return null; // if no product with the given name was found, returns null
        }
    }
}
