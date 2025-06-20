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


                Product foundProduct = storeProducts.Find(product => product.ProductName.Equals(itemName, StringComparison.OrdinalIgnoreCase)); // finds the product name and ignores the casing, product => is called a lambda expression

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

            float totalAmount = 0;
            foreach (var product in _cartProducts)
            {
                totalAmount += product.GetPrice();
            }
            Console.WriteLine($"Total amount to pay: ${totalAmount:F2}");
            Console.WriteLine();

            Console.WriteLine("What payment method are you using?");
            Console.WriteLine("1. Cash (the best, no fees)");
            Console.WriteLine("2. Card (has 2% fees)");
            Console.WriteLine("3. Paypal (has 2% fees)");

            int choice;
            while (true)
            {
                Console.Write("Enter your choice (1, 2, or 3): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice) && (choice == 1 || choice == 2 || choice == 3))
                {
                    break; // Valid input, exit the loop
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                }
            }

            Random random = new Random();
            int paymentId = random.Next(1000, 9999);

            PaymentMethod paymentMethod;

            switch (choice)
            {
                case 1:
                    paymentMethod = new Cash(paymentId, totalAmount);
                    break;
                case 2:
                    // Add 2% fee for credit card
                    float cardAmount = totalAmount * 1.02f;
                    Console.WriteLine($"Amount after 2% credit card fee: ${cardAmount:F2}");
                    paymentMethod = new CreditCard(paymentId, cardAmount);
                    break;
                case 3:
                    // Add 2% fee for PayPal
                    float paypalAmount = totalAmount * 1.02f;
                    Console.WriteLine($"Amount after 2% PayPal fee: ${paypalAmount:F2}");
                    paymentMethod = new PayPal(paymentId, paypalAmount);
                    break;
                default:
                    // This should never happen due to the validation above :)
                    Console.WriteLine("Invalid payment method. Defaulting to cash.");
                    paymentMethod = new Cash(paymentId, totalAmount);
                    break;
            }

            Console.WriteLine($"Processing payment #{paymentId}...");
            paymentMethod.ProcessPayment();

            _cartProducts.Clear(); // Clear the cart after checkout
        }
    }
}

