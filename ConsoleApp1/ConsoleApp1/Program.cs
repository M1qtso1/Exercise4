using ConsoleApp1;
class Program
{
    // The Main method creates an object of the Shop class, an object of the ConsoleUI class and calls the ShowMenu method of the ConsoleUI class
    static void Main(string[] args)
    {
        Shop shop = new Shop();
        ConsoleUI ui = new ConsoleUI(shop);
        ui.ShowMenu();
    }
}