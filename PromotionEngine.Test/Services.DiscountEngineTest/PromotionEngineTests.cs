using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.Services;
using EngineService = PromotionEngine.Services;
using PromotionEngine.Contract;

namespace PromotionEngine.Test.Services.DiscountEngineTest
{
    [TestClass()]
    public class PromotionEngineTests
    {
        [TestMethod()]
        public void ApplyPromotionWithNull()
        {
            IPromotionEngine engine = new EngineService.PromotionEngine();
            engine.ApplyPromotion(null);
        }

        [TestMethod()]
        public void ApplyPromotionWithEmptyCart()
        {
            IPromotionEngine engine = new EngineService.PromotionEngine();
            engine.ApplyPromotion(new Cart());
        }

        [TestMethod()]
        public void ApplyPromotionTestForScenarioA()
        {
            IPromotionEngine engine = new EngineService.PromotionEngine();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = 1,
                ProductInfo = new ProductInfo("A", 50)
            });
            cart.Items.Add(new CartItem()
            {
                Quantity = 1,
                ProductInfo = new ProductInfo("B", 30)
            });
            cart.Items.Add(new CartItem()
            {
                Quantity = 1,
                ProductInfo = new ProductInfo("C", 20)
            });

            engine.ApplyPromotion(cart);
            Assert.AreEqual(100, cart.TotalPrice);
        }

        [TestMethod()]
        public void ApplyPromotionTestForScenarioB()
        {
            IPromotionEngine engine = new EngineService.PromotionEngine();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = 5,
                ProductInfo = new ProductInfo("A", 50)
            });
            cart.Items.Add(new CartItem()
            {
                Quantity = 5,
                ProductInfo = new ProductInfo("B", 30)
            });
            cart.Items.Add(new CartItem()
            {
                Quantity = 1,
                ProductInfo = new ProductInfo("C", 20)
            });

            engine.ApplyPromotion(cart);
            Assert.AreEqual(370, cart.TotalPrice);
        }

        [TestMethod()]
        public void ApplyPromotionTestForScenarioC()
        {
            IPromotionEngine engine = new EngineService.PromotionEngine();

            Cart cart = new Cart();
            cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem()
            {
                Quantity = 3,
                ProductInfo = new ProductInfo("A", 50)
            });
            cart.Items.Add(new CartItem()
            {
                Quantity = 5,
                ProductInfo = new ProductInfo("B", 30)
            });
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

            engine.ApplyPromotion(cart);
            Assert.AreEqual(280, cart.TotalPrice);
        }
    }
}
