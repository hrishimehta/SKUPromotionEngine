using PromotionEngine.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Interfaces
{
    public interface IDiscountRuleEngine
    {
        void SetNextRule(IDiscountRuleEngine nextDiscountRule);

        void HandleDiscount(Cart cart);
    }
}
