using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Contract
{
    public class ProductInfo
    {
        public ProductInfo(string productId, int price)
        {
            this.Id = productId;
            this.Price = price;
        }

        public string Id { get; set; }

        public int Price { get; set; }
    }
}
