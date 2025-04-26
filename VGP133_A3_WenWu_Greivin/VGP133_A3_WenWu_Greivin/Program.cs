// See https://aka.ms/new-console-template for more information

//2. display polymorphism 
using Question_1;
using VGP133_A3_WenWu_Greivin;  // at some point i changed the name of the c# file to Question 1, that is why I am using 2 libraries haha

List<Product> products = new List<Product>();
Clothing clothing = new Clothing("Medium", "Red", "Cotton");
Electronics electronic = new Electronics("Sony", "WH-1000XM4", 4);
Book book = new Book("Greivin Wen", "Novel", 2016);

products.Add(clothing);
products.Add(electronic);
products.Add(book);

Console.WriteLine("Welcome to Wish.com");
Console.WriteLine("Here are all the products available for sale:\n");

foreach(var product in products)
{
    product.DisplayInfo();
    Console.WriteLine();
}

