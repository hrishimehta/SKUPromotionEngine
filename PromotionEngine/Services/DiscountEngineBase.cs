using PromotionEngine.Contract;
using PromotionEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    public abstract class DiscountEngineBase : IDiscountEngine
    {
        protected IDiscountEngine nextDiscountRule;

        public void SetNextRule(IDiscountEngine nextDiscountRule)
        {
            this.nextDiscountRule = nextDiscountRule;
        }

        public abstract void HandleDiscount(Cart cart);
    }
}
