using PromotionEngine.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Interfaces
{
    public interface IPromotionEngine
    {
        public void ApplyPromotion(Cart cart);
    }
}
