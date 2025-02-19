using SuperMarket.Domain.Entities;
using SuperMarket.Domain.Interfaces;

namespace SuperMarket.Domain.Rules
{
    public class PricingStrategyFactory : IPricingStrategyFactory
    {
        public IPricingStrategy GetPricingStrategy(Product productPrice)
        {
            if (productPrice.SpecialPriceQuantity > 0 && productPrice.SpecialPrice > 0)
                return new SpecialPricingStrategy(productPrice);

            return new RegularPricingStrategy(productPrice);
        }
    }
}
