using SuperMarket.Domain.Entities;

namespace SuperMarket.Domain.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductPrice(string sku);
    }
}
