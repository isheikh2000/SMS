using SuperMarket.Domain.Entities;
using SuperMarket.Domain.Interfaces;

namespace SuperMarket.Domain.Rules
{
    public class RegularPricingStrategy : IPricingStrategy
    {
        private Product _productPrice;
        
        public RegularPricingStrategy(Product productPrice)
        {
            _productPrice = productPrice;
        }

        public int GetPrice(int quantity)
        {
            return quantity * _productPrice.UnitPrice;
        }
    }
}
