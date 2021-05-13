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
        bool AddRule(int quantity, string productText, decimal price);
        bool AddRule( string product1, string product2, decimal price);
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
        public bool AddRule(int quantity, string productText, decimal price)
        {
            bool isAdded = false;
            if (!IsProductAlreadyExistsInRule(productText))
            {
                _ruleList.Add(new ProductRuleData() { RuleType = "SI", Quantity = quantity, Product1 = productText, FixedPrice = price });
                isAdded = true;
            }
            return isAdded;
        }
        public bool AddRule( string product1, string product2, decimal price)
        {
            bool isAdded = false;
            if (!IsProductAlreadyExistsInRule(product1) && !IsProductAlreadyExistsInRule(product2))
            {
                _ruleList.Add(new ProductRuleData() { RuleType = "MI", Product2 = product2, Product1 = product1, FixedPrice = price });
                isAdded = true;
            }
            return isAdded;
        }
        public void AddToCart(int qunatity, string product)
        {
            decimal price = (from item in _productList where item.ProductText == product select item.Price).FirstOrDefault();
            _cartList.Add(new ProductData() { Quantity = qunatity, ProductText = product, Price = qunatity * price, CaltulatedPrice = qunatity * price });
        }
        private bool IsProductAlreadyExistsInRule(string productText)
        {
            return _ruleList.Exists(item => item.Product1 == productText || item.Product2 == productText);
        }
    }
}
