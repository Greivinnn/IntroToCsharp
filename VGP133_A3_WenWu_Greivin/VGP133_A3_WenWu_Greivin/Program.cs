// See https://aka.ms/new-console-template for more information

//2. display polymorphism 
using Question_1;
using VGP133_A3_WenWu_Greivin;  // at some point i changed the name of the c# file to Question 1, that is why I am using 2 libraries haha

List<Product> storeProducts = new List<Product>
{
    new Electronics("Laptop", 1200.0f, 10.0f, "High-performance laptop", "Dell", "XPS 15", 2),
    new Clothing("T-Shirt", 20.0f, 5.0f, "Comfortable cotton t-shirt", "M", "Red", "Cotton"),
    new Book("C# Programming", 30.0f, 15.0f, "Learn C# programming from scratch", "John Doe", "Programming", 2023)
};

Console.WriteLine("Welcome to Wesh.com");
Console.WriteLine("Here are all the products available for sale:\n");

foreach (var product in storeProducts)
{
    product.DisplayInfo(); // Calls the overridden DisplayInfo method of each derived class
    Console.WriteLine();
}

ShoppingCart cart = new ShoppingCart();

bool exitProgram = false;
while (!exitProgram)
{
    Console.WriteLine("\nWhat would you like to do?");
    Console.WriteLine("1. Add products to cart");
    Console.WriteLine("2. Remove products from cart");
    Console.WriteLine("3. Calculate total");
    Console.WriteLine("4. Checkout");
    Console.WriteLine("5. Exit");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            cart.AddToCart(ref storeProducts);
            break;
        case "2":
            cart.RemoveFromCart(ref storeProducts);
            break;
        case "3":
            cart.CalculateTotal(ref storeProducts);
            break;
        case "4":
            cart.CheckOut(ref storeProducts);
            break;
        case "5":
            exitProgram = true;
            Console.WriteLine("Thank you for visiting Wesh.com!");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}