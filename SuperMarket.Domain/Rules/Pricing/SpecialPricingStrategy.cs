using SuperMarket.Domain.Entities;
using SuperMarket.Domain.Interfaces;

namespace SuperMarket.Domain.Rules
{
    public class SpecialPricingStrategy : IPricingStrategy
    {
        public Product _productPrice;
        
        public SpecialPricingStrategy(Product productPrice)
        {
            _productPrice = productPrice;
        }

        public int GetPrice(int quantity)
        {
            var discountedPrice = GetDiscountedPrice(quantity);

            var remainingPrice = GetRemainingPrice(quantity);

            return discountedPrice + remainingPrice;
        }

        private int GetRemainingPrice(int quantity)
        {
            return (quantity % _productPrice.SpecialPriceQuantity) * _productPrice.UnitPrice;
        }

        private int GetDiscountedPrice(int quantity)
        {
            return (quantity / _productPrice.SpecialPriceQuantity) * _productPrice.SpecialPrice;
        }
    }
}
