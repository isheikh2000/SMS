using SuperMarket.Domain.Entities;
using SuperMarket.Domain.Interfaces;

namespace SuperMarket.UnitTests.TestData
{
    public class ProductPriceRepositoryTestData : IProductPriceRepository
    {
        private readonly List<ProductPrice> _productPrices;
        
        public ProductPriceRepositoryTestData()
        {
            _productPrices = new List<ProductPrice>
            {
                new ProductPrice { SKU = "A", UnitPrice = 50, SpecialPriceQuantity = 3, SpecialPrice =  130 },
                new ProductPrice { SKU = "B", UnitPrice = 30, SpecialPriceQuantity = 2, SpecialPrice =  45},
                new ProductPrice { SKU = "C", UnitPrice = 20, },
                new ProductPrice { SKU = "D", UnitPrice = 15, },
            };
        }
        public ProductPrice GetProductPrice(string sku)
        {
            return _productPrices.FirstOrDefault(x=> x.SKU == sku);
        }
    }
}
