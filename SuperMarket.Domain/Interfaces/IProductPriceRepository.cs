using SuperMarket.Domain.Entities;

namespace SuperMarket.Domain.Interfaces
{
    public interface IProductPriceRepository
    {
        ProductPrice GetProductPrice(string sku);
    }
}
