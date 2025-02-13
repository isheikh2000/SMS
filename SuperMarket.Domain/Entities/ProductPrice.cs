namespace SuperMarket.Domain.Entities
{
    public class ProductPrice
    {
        public string SKU { get; set; }

        public int UnitPrice { get; set; }

        public int SpecialPriceQuantity { get; set; }

        public int SpecialPrice { get; set; }
    }
}
