using SuperMarket.Domain.Entities;
using SuperMarket.Domain.Interfaces;

namespace SuperMarket.UnitTests.TestData
{
    public class ProductRepositoryTestData : IProductRepository
    {
        private readonly List<Product> _productPrices;
        
        public ProductRepositoryTestData()
        {
            _productPrices = new List<Product>
            {
                new Product { SKU = "A", UnitPrice = 50, SpecialPriceQuantity = 3, SpecialPrice =  130 },
                new Product { SKU = "B", UnitPrice = 30, SpecialPriceQuantity = 2, SpecialPrice =  45},
                new Product { SKU = "C", UnitPrice = 20, },
                new Product { SKU = "D", UnitPrice = 15, },
            };
        }
        public Product GetProductPrice(string sku)
        {
            return _productPrices.FirstOrDefault(x=> x.SKU == sku);
        }
    }
}
