using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public interface IPrductBase
    {
        void AddProduct(string product, decimal price);
        void AddRule(string ruleType, int quantity, string productText, decimal price);
        void AddRule(string ruleType, string product1, string product2, decimal price);
        void AddToCart(int qunatity, string product);
        decimal GetTotal();
        void ExecuteRules();
    }
    public abstract class BaseService :BaseDispose,IPrductBase
    {
        protected List<ProductData> _productList;
        protected List<ProductRuleData> _ruleList;
        protected List<ProductData> _cartList;
        public BaseService()
        {
            _productList = new List<ProductData>();
            _ruleList = new List<ProductRuleData>();
            _cartList = new List<ProductData>();
        }
        public abstract void ExecuteRules();
        public abstract decimal GetTotal();
   
        public void AddProduct(string product, decimal price)
        {
            _productList.Add(new ProductData() { ProductText = product, Price = price });
        }
        public void AddRule(string ruleType, int quantity, string productText, decimal price)
        {
            _ruleList.Add(new ProductRuleData() { RuleType = ruleType, Quantity = quantity, Product1 = productText, FixedPrice = price });
        }
        public void AddRule(string ruleType, string product1, string product2, decimal price)
        {
            _ruleList.Add(new ProductRuleData() { RuleType = ruleType, Product2 = product2, Product1 = product1, FixedPrice = price });
        }
        public void AddToCart(int qunatity, string product)
        {
            decimal price = (from item in _productList where item.ProductText == product select item.Price).FirstOrDefault();
            _cartList.Add(new ProductData() { Quantity = qunatity, ProductText = product, Price = qunatity * price, CaltulatedPrice = qunatity * price });
        }
      
    }
}
