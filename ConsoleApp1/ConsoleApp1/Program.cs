using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

// The Program class contains the Main method, which is the entry point to the application
class Program
{
    // The Main method creates an object of the Shop class, an object of the ConsoleUI class and calls the ShowMenu method of the ConsoleUI class
    static void Main(string[] args)
    {
        Shop shop = new Shop(); // creating an object of the Shop class
        ConsoleUI ui = new ConsoleUI(shop); // creating an object of the ConsoleUI class with the given argument
        ui.ShowMenu(); // calling ShowMenu method of the ConsoleUI class
    }
}
