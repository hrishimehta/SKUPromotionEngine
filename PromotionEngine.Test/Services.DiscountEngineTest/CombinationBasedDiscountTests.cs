using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Contract;
using PromotionEngine.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Test.Services.DiscountEngineTest
{
    [TestClass()]
    public class CombinationBasedDiscountTests
    {
        [TestMethod()]
        public void CombinationBasedDiscount_ShouldNotFailForNull()
        {
            CombinationBasedDiscount combinationBasedDiscount = new CombinationBasedDiscount();
            combinationBasedDiscount.HandleDiscount(null);
        }

        [TestMethod()]
        public void CombinationBasedDiscount_ShouldNotFailForEmptyCart()
        {
            CombinationBasedDiscount combinationBasedDiscount = new CombinationBasedDiscount();
            combinationBasedDiscount.HandleDiscount(new Cart());
        }

        [TestMethod()]
        public void CombinationBasedDiscount_SetNextRule_ShouldNotFailForNull()
        {
            CombinationBasedDiscount combinationBasedDiscount = new CombinationBasedDiscount();
            combinationBasedDiscount.SetNextRule(null);
        }


        [TestMethod()]
        public void HandleDiscountForCorrectCombination()
        {
            CombinationBasedDiscount combinationBasedDiscount = new CombinationBasedDiscount();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = 1,
                ProductInfo = new ProductInfo("C", 20)
            });

            cart.Items.Add(new CartItem()
            {
                Quantity = 1,
                ProductInfo = new ProductInfo("D", 15)
            });


            combinationBasedDiscount.HandleDiscount(cart);
            Assert.AreEqual(30, cart.TotalPrice);
        }

        [TestMethod()]
        public void HandleDiscountForNotFindingCombination()
        {
            CombinationBasedDiscount combinationBasedDiscount = new CombinationBasedDiscount();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = 10,
                ProductInfo = new ProductInfo("C", 20)
            });


            combinationBasedDiscount.HandleDiscount(cart);
            Assert.AreEqual(200, cart.TotalPrice);
        }


        [TestMethod()]
        public void HandleDiscountForMultipleCorrectCombination()
        {
            CombinationBasedDiscount combinationBasedDiscount = new CombinationBasedDiscount();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = 4,
                ProductInfo = new ProductInfo("C", 20)
            });

            cart.Items.Add(new CartItem()
            {
                Quantity = 5,
                ProductInfo = new ProductInfo("D", 15)
            });


            combinationBasedDiscount.HandleDiscount(cart);
            Assert.AreEqual(135, cart.TotalPrice);
        }


        [TestMethod()]
        public void HandleDiscountForMultipleCorrectCombinationWithNegativeQuantity()
        {
            CombinationBasedDiscount combinationBasedDiscount = new CombinationBasedDiscount();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = -4,
                ProductInfo = new ProductInfo("C", 20)
            });

            cart.Items.Add(new CartItem()
            {
                Quantity = -5,
                ProductInfo = new ProductInfo("D", 15)
            });


            combinationBasedDiscount.HandleDiscount(cart);
            // handle negative price befoe applying promotion
            Assert.AreEqual(-155, cart.TotalPrice);
        }
    }
}
