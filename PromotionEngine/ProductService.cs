using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class ProductService : BaseService
    {
        public ProductService()
        {

        }
        public override void ExecuteRules()
        {
            foreach (ProductRuleData ruleInfo in _ruleList)
            {
                if (ruleInfo.RuleType == "SI")
                {
                    if (_cartList.Exists(cItem => cItem.ProductText == ruleInfo.Product1))
                    {
                        foreach (ProductData cartInfo in _cartList)
                        {
                            if (ruleInfo.Product1 == cartInfo.ProductText && cartInfo.Quantity >= ruleInfo.Quantity)
                            {
                                //finding out howmany rule quantity matching.
                                int tQnt = cartInfo.Quantity / ruleInfo.Quantity;
                                //finding remaining qunaities.
                                int remainQnt = cartInfo.Quantity % ruleInfo.Quantity;
                                
                                cartInfo.CaltulatedPrice = (tQnt * ruleInfo.FixedPrice) + (cartInfo.Price * remainQnt);
                            }
                        }
                    }
                }
                else
                {
                    if (_cartList.Exists(cItem => cItem.ProductText == ruleInfo.Product1 && cItem.ProductText == ruleInfo.Product2))
                    {
                        foreach (ProductData cartInfo in _cartList)
                        {
                            if (ruleInfo.Product1 == cartInfo.ProductText)
                            {
                                cartInfo.CaltulatedPrice = 0;//skipping value as we are setting to second value.
                            }
                            else if (ruleInfo.Product2 == cartInfo.ProductText)
                            {
                                cartInfo.CaltulatedPrice = ruleInfo.FixedPrice;
                            }
                        }
                    }
                }
            }
        }
        public override decimal GetTotal()
        {
            if (_cartList.Count > 0)
                return _cartList.Sum(item => item.CaltulatedPrice);
            else return 0;
        }

     
    }
}
