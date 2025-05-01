using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGP133_A3_WenWu_Greivin;

namespace Question_1
{
    public class ShoppingCart : IShoppingCart
    {
        private List<Product> _cartProducts = new List<Product>();

        public void AddToCart(ref List<Product> storeProducts) // Add product to the shopping cart
        {
            while(true)
            {
                Console.WriteLine("What product would you like to add to the shopping cart? (Type 'done' to finish)");
                string itemName = Console.ReadLine();

                if (itemName.Equals("done", StringComparison.OrdinalIgnoreCase))    // ignores if the user inputs Done or done.
                {
                    return;
                }

                Product foundProduct = storeProducts.Find(product => product._productName.Equals(itemName, StringComparison.OrdinalIgnoreCase)); // finds the product name and ignores the casing, product => is called a lambda expression

                if (foundProduct != null)
                {
                    _cartProducts.Add(foundProduct);
                    Console.WriteLine(($"'{itemName}' has been added to your shopping cart!"));
                }
                else
                {
                    Console.WriteLine(($"'{itemName}' is not available in the store, please try again"));
                }
            }
        }
        public void RemoveFromCart(ref List<Product> storeProducts)     // Remove product from cart
        {
            while (true)
            {
                Console.WriteLine("What product would you like to remove from the shopping cart? (Type 'done' to finish)");
                string itemName = Console.ReadLine();

                if (itemName.Equals("done", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                // Find the product in the cart
                Product foundProduct = _cartProducts.Find(product => product.ProductName.Equals(itemName, StringComparison.OrdinalIgnoreCase));

                if (foundProduct != null)
                {
                    _cartProducts.Remove(foundProduct);
                    Console.WriteLine($"'{itemName}' has been removed from your shopping cart.");
                }
                else
                {
                    Console.WriteLine($"'{itemName}' is not in your shopping cart. Please try again.");
                }
            }
        }
        public void CalculateTotal(ref List<Product> storeProducts)
        {
            float total = 0;

            foreach (var product in _cartProducts)
            {
                total += product.GetPrice();
            }

            if (total > 100)    // if the order is bigger than 100 the client gets a discount of 10
            {
                Console.WriteLine("Congratulations! You have unlocked a discount of 10% with your order!");
                Console.WriteLine($"Total before discount: {total}");
                total *= 0.9f; // apply 10 percent discount
                Console.WriteLine($"Total after discount: {total}");
            }
            Console.WriteLine($"The total price of your shopping cart is: ${total:F2}"); // total:F2 lets us only display 2 decimal places
        }
        public void CheckOut(ref List<Product> storeProducts)
        {
            if (_cartProducts.Count == 0)
            {
                Console.WriteLine("Your shopping cart is empty. Add some products before checking out.");
                return;
            }

            Console.WriteLine("Checking out the following items:");
            foreach (var product in _cartProducts)
            {
                product.DisplayInfo();
            }

            _cartProducts.Clear(); // Clear the cart after checkout
            Console.WriteLine("Thank you for your purchase!");
        }
    }
}

