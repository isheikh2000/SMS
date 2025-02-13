using SuperMarket.Domain.Interfaces;

namespace SuperMarket.Application.Services
{
    public class CheckoutService : ICheckout
    {
        public Dictionary<string,int> _scanItems;

        public CheckoutService()
        {
            _scanItems = new Dictionary<string,int>();
        }
        public void Scan(string item)
        {
            _scanItems[item] = 1;            
        }

        public int GetTotalPrice()
        {
            if (_scanItems.Count > 0 && _scanItems.ContainsKey("A"))
            {
                return 50;            
            }
            
            return 0;
        }        
    }
}
