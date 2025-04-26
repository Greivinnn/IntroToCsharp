using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGP133_A3_WenWu_Greivin;

namespace Question_1
{
    public interface IShoppingCart
    {
        public void AddToCart(ref List<Product> storeProducts);
        public void RemoveFromCart(ref List<Product> storeProducts);
        public void CalculateTotal(ref List<Product> storeProducts);
        public void CheckOut(ref List<Product> storeProducts);
    }
}
