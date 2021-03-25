using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Contract
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }

        // keeping this int but can be change as object to show breakdown of discount
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


        public int TotalPrice
        {
            get
            {
                return this.Items.Sum(item => item.Price) - DisocuntPrice;
            }
        }
    }
}
