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
        public void AddToCart(ref List<Product> storeProducts)
        {
            while(true)
            {
                string itemName;

                Console.WriteLine("What product would you like to add to the shopping cart?");
                itemName = Console.ReadLine();

                if (itemName == "done")
                {
                    return;
                }
                else
                {
                    if (storeProducts.Equals(itemName))
                    {

                    }
                    else
                    {

                    }
                }
            }
        }
        public void RemoveFromCart(ref List<Product> storeProducts)
        {

        }
        public void CalculateTotal(ref List<Product> storeProducts)
        {

        }
        public void CheckOut(ref List<Product> storeProducts)
        {

        }
    }
}

