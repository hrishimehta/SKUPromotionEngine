using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Contract;

namespace PromotionEngine.Services
{
    public class QuantityBasedDiscount : DiscountEngineBase
    {
        private List<QuantityBasedRuleInfo> discountRule;

        public QuantityBasedDiscount()
        {
            // this set of rule can be fetched from DB like PromotionRule table 
            // with Promotion type as "QuantityBaseDiscount"            
            this.discountRule = new List<QuantityBasedRuleInfo>();

            // For item Id A with 3 Quantity provide discount of 20
            this.discountRule.Add(new QuantityBasedRuleInfo("A", 3, 20));
            this.discountRule.Add(new QuantityBasedRuleInfo("B", 2, 15));
        }

        public override void HandleDiscount(Cart cart)
        {
            if (cart != null && cart.Items != null && cart.Items.All(item => item.Quantity >= 0))
            {
                foreach (var rule in this.discountRule)
                {
                    if (cart.Items.Any(item => item.ProductInfo.Id.Equals(rule.ProductId)))
                    {
                        var item = cart.Items.First(item => item.ProductInfo.Id.Equals(rule.ProductId));
                        var totalDiscountForItem = (item.Quantity / rule.Quantity) * rule.Discount;
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
