using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Contract
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }

        public int DisocuntPrice { get; set; }

        public Dictionary<string, int> ItemToQuantity
        {
            get
            {
                // can be improved by making Items property private and exposing AddCart method
                var dict = new Dictionary<string, int>();
                foreach (var item in Items)
                {
                    if (dict.ContainsKey(item.ProductInfo.Id))
                    {
                        dict[item.ProductInfo.Id] += item.Quantity;
                    }
                    else
                    {
                        dict.Add(item.ProductInfo.Id, item.Quantity);
                    }

                }

                return dict;
            }
        }
    }
}
