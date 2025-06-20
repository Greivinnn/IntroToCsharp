// See https://aka.ms/new-console-template for more information
using Question_4;

Console.WriteLine("Question 4\n");

List<Item> items = new List<Item>();

Console.WriteLine("All item types: Equipment, Consumable, KeyItem\n");

items.Add(new Item
{
    ItemName = "Bronze Sword",
    ItemType = "Equipment",
    Quantity = 1
});
items.Add(new Item
{
    ItemName = "Candy",
    ItemType = "Consumable",
    Quantity = 20
});
items.Add(new Item
{
    ItemName = "Silver Shield",
    ItemType = "Equipment",
    Quantity = 1
});
items.Add(new Item
{
    ItemName = "Gold Key",
    ItemType = "KeyItem",
    Quantity = 1
});
items.Add(new Item
{
    ItemName = "Golden Trophy",
    ItemType = "KeyItem",
    Quantity = 1
});
items.Add(new Item
{
    ItemName = "Tacos",
    ItemType = "Consumable",
    Quantity = 99
});

Item.PrintItems(items);

Console.WriteLine("Filter the items by what type? ");
string input = Console.ReadLine();

// instead of doing an if statement for each type, we just create a LINQ that compares the input of user and the existing item.ItemType
// this helps with the logic of adding new item types to the program. So we do not need to add if statements each time a new type is added
var filteredItems = items
    .Where(item => item.ItemType.Equals(input, StringComparison.OrdinalIgnoreCase))
    .ToList();
// if filteredItems is bigger than 0 means is populated and we print it out
if (filteredItems.Count > 0)
{
    Console.WriteLine($"\nFiltered by '{input}':");
    foreach (var item in filteredItems)
    {
        Console.WriteLine(item.ItemName + " (" + item.ItemType + ")" + " x" + item.Quantity);
    }
}
else
{
    Console.WriteLine($"\nNo items found for type '{input}'.");
}

// Code before update:

//....
//Console.WriteLine("Filter the items by what type? ");
//string input = Console.ReadLine();

//if (input.Equals("Equipment", StringComparison.OrdinalIgnoreCase))
//{
//    var query1 = from item in items
//                 where item.ItemType == "Equipment"
//                 select item;
//    Console.WriteLine("Filtered by 'Equipment':");
//    foreach (var item in query1)
//    {
//        Console.WriteLine(item.ItemName + " (" + item.ItemType + ")" + " x" + item.Quantity);
//    }
//}
//else if (input.Equals("Consumable", StringComparison.OrdinalIgnoreCase))
//{
//    var query2 = from item in items
//                 where item.ItemType == "Consumable"
//                 select item;
//    Console.WriteLine("Filtered by 'Consumable':");
//    foreach (var item in query2)
//    {
//        Console.WriteLine(item.ItemName + " (" + item.ItemType + ")" + " x" + item.Quantity);
//    }
//}
//else if (input.Equals("KeyItem", StringComparison.OrdinalIgnoreCase))
//{
//    var query3 = from item in items
//                 where item.ItemType == "KeyItem"
//                 select item;
//    Console.WriteLine("Filtered by 'KeyItem':");
//    foreach (var item in query3)
//    {
//        Console.WriteLine(item.ItemName + " (" + item.ItemType + ")" + " x" + item.Quantity);
//    }
//}
//else
//{
//    Console.WriteLine("Error. Unavailable Item Type.");
//}



