using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionEngineTest
{
    [TestClass]
    public class ProductServiceTest
    {
        IPrductBase productServ = null;
        public ProductServiceTest()
        {
            CreateDefault();
        }
        public void CreateDefault()
        {
            productServ = new ProductService();
            productServ.AddProduct("A", 50);
            productServ.AddProduct("B", 30);
            productServ.AddProduct("C", 20);
            productServ.AddProduct("D", 15);
            productServ.AddRule(3, "A", 130);
            productServ.AddRule( 2, "B", 45);
            productServ.AddRule("C", "D", 30);
        }
        [TestMethod]
        public void ScenarioA()
        {
            productServ.AddToCart(1, "A");
            productServ.AddToCart(1, "B");
            productServ.AddToCart(1, "C");
            productServ.ExecuteRules();
            decimal total = productServ.GetTotal();
            Assert.AreEqual(total, 100);
        }
        [TestMethod]
        public void ScenarioB()
        {
            productServ.AddToCart(5, "A");
            productServ.AddToCart(5, "B");
            productServ.AddToCart(1, "C");
            productServ.ExecuteRules();
            decimal total = productServ.GetTotal();
            Assert.AreEqual(total, 370);
        }
        [TestMethod]
        public void ScenarioC()
        {
            productServ.AddToCart(3, "A");
            productServ.AddToCart(5, "B");
            productServ.AddToCart(1, "C");
            productServ.AddToCart(1, "D");
            productServ.ExecuteRules();
            decimal total = productServ.GetTotal();
            Assert.AreEqual(total, 280);
        }
    }
}
