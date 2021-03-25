using PromotionEngine.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Interfaces
{
    public interface IDiscountEngine
    {
        void SetNextRule(IDiscountEngine nextDiscountRule);

        void HandleDiscount(Cart cart);
    }
}
