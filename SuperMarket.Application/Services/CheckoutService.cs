using SuperMarket.Domain.Entities;
using SuperMarket.Domain.Exceptions;
using SuperMarket.Domain.Interfaces;
using SuperMarket.Domain.Rules;


namespace SuperMarket.Application.Services
{
    public class CheckoutService : ICheckout
    {
        private IProductRepository _priceRepository;

        private IPricingStrategyFactory _factory;
        
        private Dictionary<string,int> _scanItems;

        public CheckoutService(IProductRepository priceRepository, IPricingStrategyFactory factory)
        {
            _priceRepository = priceRepository;

            _factory = factory;

            _scanItems = new Dictionary<string,int>();         
        }
        public void Scan(string item)
        {
            var validItem = _priceRepository.GetProductPrice(item);

            if (validItem == null)
                throw new InvalidProductException(item);

            if (_scanItems.ContainsKey(item))
            {
                _scanItems[item]++;
            }
            else
            {
                _scanItems.Add(item, 1);
            }
        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;
            
            foreach (var item in _scanItems)
            {
                var productPrice = _priceRepository.GetProductPrice(item.Key);

                var strategy = _factory.GetPricingStrategy(productPrice);
                
                totalPrice += strategy.GetPrice(item.Value);

            }           
            
            return totalPrice;
        }          
    }
}
