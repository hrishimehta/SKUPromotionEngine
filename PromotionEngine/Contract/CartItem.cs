using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Contract
{
    public class CartItem
    {
        public ProductInfo ProductInfo { get; set; }

        public int Quantity { get; set; }

        public int Price
        {
            get
            {
                return (Quantity * this.ProductInfo.Price);
            }
        }
    }
}
