using PromotionEngine.Contract;
using PromotionEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    public abstract class DiscountEngineBase : IDiscountRuleEngine
    {
        protected IDiscountRuleEngine nextDiscountRule;

        public void SetNextRule(IDiscountRuleEngine nextDiscountRule)
        {
            this.nextDiscountRule = nextDiscountRule;
        }

        public abstract void HandleDiscount(Cart cart);
    }
}
