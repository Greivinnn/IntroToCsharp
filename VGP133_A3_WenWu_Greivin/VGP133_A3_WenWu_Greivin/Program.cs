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
cart.AddToCart(ref storeProducts);
cart.CalculateTotal(ref storeProducts);
cart.CheckOut(ref storeProducts);