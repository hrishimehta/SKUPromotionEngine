using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Contract;
using PromotionEngine.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Test.Services.DiscountEngineTest
{
    [TestClass()]
    public class QuantityBasedDiscountTests
    {
        [TestMethod()]
        public void QuantityBasedDiscount_ShouldNotFailForNull()
        {
            QuantityBasedDiscount quantityBasedDiscount = new QuantityBasedDiscount();
            quantityBasedDiscount.HandleDiscount(null);
        }

        [TestMethod()]
        public void QuantityBasedDiscount_ShouldNotFailForEmptyCart()
        {
            QuantityBasedDiscount quantityBasedDiscount = new QuantityBasedDiscount();
            quantityBasedDiscount.HandleDiscount(new Cart());
        }

        [TestMethod()]
        public void QuantityBasedDiscount_SetNextRule_ShouldNotFailForNull()
        {
            QuantityBasedDiscount quantityBasedDiscount = new QuantityBasedDiscount();
            quantityBasedDiscount.SetNextRule(null);
        }


        [TestMethod()]
        public void HandleDiscountForItemA()
        {
            QuantityBasedDiscount quantityBasedDiscount = new QuantityBasedDiscount();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = 3,
                ProductInfo = new ProductInfo("A", 50)
            });

            quantityBasedDiscount.HandleDiscount(cart);
            Assert.AreEqual(130, cart.TotalPrice);
        }

        [TestMethod()]
        public void HandleDiscountForFiveItemA()
        {
            QuantityBasedDiscount quantityBasedDiscount = new QuantityBasedDiscount();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = 5,
                ProductInfo = new ProductInfo("A", 50)
            });

            quantityBasedDiscount.HandleDiscount(cart);
            Assert.AreEqual(230, cart.TotalPrice);
        }

        [TestMethod()]
        public void HandleDiscountForNegativeFiveItemA()
        {
            QuantityBasedDiscount quantityBasedDiscount = new QuantityBasedDiscount();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = -5,
                ProductInfo = new ProductInfo("A", 50)
            });

            quantityBasedDiscount.HandleDiscount(cart);

            // handle negative price before applying promotion
            Assert.AreEqual(-250, cart.TotalPrice);
        }

        [TestMethod()]
        public void HandleDiscountForItemB()
        {
            QuantityBasedDiscount quantityBasedDiscount = new QuantityBasedDiscount();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = 2,
                ProductInfo = new ProductInfo("B", 30)
            });

            quantityBasedDiscount.HandleDiscount(cart);
            Assert.AreEqual(45, cart.TotalPrice);
        }

        [TestMethod()]
        public void HandleDiscountForFiveItemB()
        {
            QuantityBasedDiscount quantityBasedDiscount = new QuantityBasedDiscount();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = 5,
                ProductInfo = new ProductInfo("B", 30)
            });

            quantityBasedDiscount.HandleDiscount(cart);
            Assert.AreEqual(120, cart.TotalPrice);
        }
    }
}
