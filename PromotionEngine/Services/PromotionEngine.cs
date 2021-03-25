using PromotionEngine.Contract;
using PromotionEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    public class PromotionEngine : IPromotionEngine
    {
        private IDiscountEngine ruleEngine;

        public void SetDiscountSequence()
        {
            // for more customization like to include specific rule,exclude rule, controlling sequence
            // we may need to modify this with factory which can do below task based on input
            IDiscountEngine quantityEngine = new QuantityBasedDiscount();
            IDiscountEngine combinationEngine = new CombinationBasedDiscount();

            quantityEngine.SetNextRule(combinationEngine);

            this.ruleEngine = quantityEngine;
        }

        public void ApplyPromotion(Cart cart)
        {
            this.ruleEngine.HandleDiscount(cart);
        }
    }
}
