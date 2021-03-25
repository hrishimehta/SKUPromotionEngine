using PromotionEngine.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Services
{
    public class CombinationBasedDiscount : DiscountEngineBase
    {
        private List<Tuple<List<string>, int>> discountRule;

        public CombinationBasedDiscount()
        {
            // this set of rule can be fetched from DB/Service like PromotionRule table 
            // with Promotion type as "CombinationBasedDiscount"            
            this.discountRule = new List<Tuple<List<string>, int>>();

            // For item Id C and D with provide discount of 5
            this.discountRule.Add(new Tuple<List<string>, int>(new List<string>() { "C", "D" }, 5));
        }

        public override void HandleDiscount(Cart cart)
        {
            if (cart != null && cart.Items != null && cart.Items.All(item => item.Quantity >= 0))
            {
                var allItemId = cart.Items.Select(item => item.ProductInfo.Id).Distinct();

                foreach (var rule in this.discountRule)
                {
                    // check if all combination of rule exist in cart
                    var containsAll = rule.Item1.All(i => cart.ItemToQuantity.Keys.Contains(i));

                    if (containsAll)
                    {
                        // if C has 4 item and D has 5 item we need value "4" as
                        // there are 4 combination exist hence 4 time discount

                        // take first count as minimum
                        int min = cart.ItemToQuantity[rule.Item1.First()];

                        // need to iterate as we can configure this rule for combination of N number of item
                        foreach (var item in rule.Item1.Skip(1))
                        {
                            min = Math.Min(cart.ItemToQuantity[item], min);
                        }

                        // apply final discount
                        cart.DisocuntPrice += min * rule.Item2;
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
