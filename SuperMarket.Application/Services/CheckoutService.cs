using SuperMarket.Domain.Entities;
using SuperMarket.Domain.Interfaces;

namespace SuperMarket.Application.Services
{
    public class CheckoutService : ICheckout
    {
        private IProductPriceRepository _priceRepository;
        
        private Dictionary<string,int> _scanItems;

        public CheckoutService(IProductPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;

            _scanItems = new Dictionary<string,int>();         
        }
        public void Scan(string item)
        {
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
                var price = _priceRepository.GetProductPrice(item.Key);

                if (IsSpecialPrice(price))
                {
                    totalPrice += (item.Value / price.SpecialPriceQuantity) * price.SpecialPrice;
                    totalPrice += (item.Value % price.SpecialPriceQuantity) * price.UnitPrice;
                }
                else
                {
                    totalPrice += (item.Value * price.UnitPrice);
                }
            }           
            
            return totalPrice;
        }          

        private bool IsSpecialPrice(ProductPrice price)
        {
            return price.SpecialPriceQuantity > 0 && price.SpecialPrice > 0;
        }

    }
}
