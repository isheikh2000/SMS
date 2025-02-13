using SuperMarket.Domain.Entities;
using SuperMarket.Domain.Interfaces;

namespace SuperMarket.Infrastructure.Repositories
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        private List<ProductPrice> _products;

        //"In the real world, we pass the ApplicationDbContext to interact with the Entity Framework Core context
        //and retrieve product price data from the database."        
        public ProductPriceRepository()
        {
            _products = new List<ProductPrice>
            {
                new ProductPrice { SKU = "A", UnitPrice = 50, SpecialPriceQuantity = 3, SpecialPrice =  130 },
                new ProductPrice { SKU = "B", UnitPrice = 30, SpecialPriceQuantity = 2, SpecialPrice =  45},
                new ProductPrice { SKU = "C", UnitPrice = 20, },
                new ProductPrice { SKU = "D", UnitPrice = 15, },

            };
        }

        public ProductPrice GetProductPrice(string sku)
        {
            return _products.FirstOrDefault(x => x.SKU == sku);
        }
    }
}
