using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Contract
{
    public class QuantityBasedRuleInfo
    {
        public QuantityBasedRuleInfo(string productId,int qty,int discount)
        {
            this.ProductId = productId;
            this.Quantity = qty;
            this.Discount = discount;
        }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public int Discount { get; set; }

    }
}
