using SuperMarket.Domain.Entities;
using SuperMarket.Domain.Interfaces;

namespace SuperMarket.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        //"In the real world, we pass the ApplicationDbContext to interact with the Entity Framework Core context
        //and retrieve product price data from the database."        
        public ProductRepository()
        {
            _products = new List<Product>
            {
                new Product { SKU = "A", UnitPrice = 50, SpecialPriceQuantity = 3, SpecialPrice =  130 },
                new Product { SKU = "B", UnitPrice = 30, SpecialPriceQuantity = 2, SpecialPrice =  45},
                new Product { SKU = "C", UnitPrice = 20, },
                new Product { SKU = "D", UnitPrice = 15, },

            };
        }

        public Product GetProductPrice(string sku)
        {
            return _products.FirstOrDefault(x => x.SKU == sku);
        }
    }
}
