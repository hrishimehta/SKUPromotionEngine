using PromotionEngine.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Services
{
    public class QuantityBasedDiscount : DiscountEngineBase
    {
        private List<Tuple<string, int, int>> discountRule;

        public QuantityBasedDiscount()
        {
            // this set of rule can be fetched from DB like PromotionRule table 
            // with Promotion type as "QuantityBaseDiscount"            
            this.discountRule = new List<Tuple<string, int, int>>();

            // For item Id A with 3 Quantity provide discount of 20
            this.discountRule.Add(new Tuple<string, int, int>("A", 3, 20));
            this.discountRule.Add(new Tuple<string, int, int>("B", 2, 15));
        }

        public override void HandleDiscount(Cart cart)
        {
            if (cart != null && cart.Items != null && cart.Items.All(item => item.Quantity >= 0))
            {
                foreach (var rule in this.discountRule)
                {
                    if (cart.Items.Any(item => item.ProductInfo.Id.Equals(rule.Item1)))
                    {
                        var item = cart.Items.First(item => item.ProductInfo.Id.Equals(rule.Item1));
                        var totalDiscountForItem = (item.Quantity / rule.Item2) * rule.Item3;
                        cart.DisocuntPrice += totalDiscountForItem;
                    }
                }
            }

            if (nextDiscountRule != null)
            {
                nextDiscountRule.HandleDiscount(cart);
            }
        }
    }
}
