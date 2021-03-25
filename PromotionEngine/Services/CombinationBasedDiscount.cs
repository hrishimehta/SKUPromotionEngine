using PromotionEngine.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Services
{
    public class CombinationBasedDiscount : DiscountEngineBase
    {
        private List<CombinationRuleInfo> discountRule;

        public CombinationBasedDiscount()
        {
            // this set of rule can be fetched from DB/Service like PromotionRule table 
            // with Promotion type as "CombinationBasedDiscount"            
            this.discountRule = new List<CombinationRuleInfo>();

            // For item Id C and D with provide discount of 5            
            this.discountRule.Add(new CombinationRuleInfo()
            {
                ProductIds = new List<string>() { "C", "D" },
                Discount = 5
            });
        }

        public override void HandleDiscount(Cart cart)
        {
            if (cart != null && cart.Items != null && cart.Items.All(item => item.Quantity >= 0))
            {
                var allItemId = cart.Items.Select(item => item.ProductInfo.Id).Distinct();

                foreach (var rule in this.discountRule)
                {
                    // check if all combination of rule exist in cart
                    var containsAll = rule.ProductIds.All(i => cart.ItemToQuantity.Keys.Contains(i));

                    if (containsAll)
                    {
                        // if C has 4 item and D has 5 item we need value "4" as
                        // there are 4 combination exist hence 4 time discount

                        // take first count as minimum
                        int min = cart.ItemToQuantity[rule.ProductIds.First()];

                        // need to iterate as we can configure this rule for combination of N number of item
                        // and take min of N item
                        foreach (var item in rule.ProductIds.Skip(1))
                        {
                            min = Math.Min(cart.ItemToQuantity[item], min);
                        }

                        // apply final discount
                        // min indicates minimum number of combination found
                        // so final disocunt would be (number of combination * discount)
                        cart.DisocuntPrice += min * rule.Discount;
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
