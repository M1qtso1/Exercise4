using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // The Shop class represents a store with a list of products and methods for managing them
    public class Shop
    {
        private List<Product> products; // list of products

        // The Shop class constructor creates an empty list of products
        public Shop()
        {
            products = new List<Product>();
        }

        // The get method returns the list of products
        public List<Product> Products
        {
            get { return products; }
        }

        // The AddProduct method adds a product to the list of products
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // The ShowProducts method displays information about all products in the store
        public void ShowProducts()
        {
            Console.WriteLine("List of products in the store: \n");
            foreach (Product product in products)
            {
                Console.WriteLine(product + "\n_____________________");
            }
        }

        // The SellProduct method sells a product to a customer, reduces its quantity in the store and displays information about the sale
        public void SellProduct(Product product, Customer customer)
        {
            if (product.Quantity > 0) // checks if the product is available
            {
                product.Quantity--; // reduces the product quantity by 1
                customer.Buy(this, product); // calls the Buy method of the Customer 
                Console.WriteLine($"Sold product {product.Name} to customer {customer.Name} for {product.Price} USD.\n_____________________");
            }
            else // if the product is unavailable, displays a message about out of stock
            {
                Console.WriteLine($"Product {product.Name} is out of stock.\n_____________________");
            }
        }

        // The SaveProducts method allows the user to save the list of products to a JSON file, asking for the file name and calling the SaveProducts method of the Shop class
        public void SaveProducts(string fileName)
        {
            // Creating serialization options with ignoring default values and formatting indents
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            // Checking if the file name has a .json extension
            string extension = Path.GetExtension(fileName);
            while (extension != ".json") // while the extension is not .json
            {
                Console.WriteLine("The file name is invalid. Please enter a file name with a .json extension.");
                Console.Write("Enter file name: ");
                fileName = Console.ReadLine(); // reading file name from user again
                extension = Path.GetExtension(fileName); // getting the extension again
            }
            // If the extension is .json, the loop will end and you can continue with your code

            // Creating a file stream to write data
            using (FileStream fs = File.Create(fileName))
            {
                // Serializing the list of products to JSON format and writing to the file stream
                JsonSerializer.SerializeAsync(fs, products, options);
            }
        }


        // The LoadProducts method loads the list of products from a JSON file
        public void LoadProducts(string fileName)
        {
            if (File.Exists(fileName))// Creating a file stream to read data
            {
                using (FileStream fs = File.OpenRead(fileName))
                {
                    // Deserializing data from JSON format to a list of products and assigning to the class field
                    products = JsonSerializer.DeserializeAsync<List<Product>>(fs).Result;
                }
            }
            else
            {
                Console.WriteLine($"The file {fileName} does not exist.\n_____________________"); // using FileName property to get the name of the missing file
            }
        }
    }
}
